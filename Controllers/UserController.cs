using System;
using System.Net;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using record_keep_api.DBO;
using record_keep_api.Error;
using record_keep_api.Models.Error.User;
using record_keep_api.Models.User;
using record_keep_api.Models.UserActivity;
using record_keep_api.Services;
using record_keep_auth_service;

namespace record_keep_api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : CustomControllerBase
    {
        private readonly IAuthService _authService;
        private readonly DatabaseContext _databaseContext;
        private readonly IUserActivityService _userActivityService;

        public UserController(DatabaseContext context, IAuthService authService,
            IUserActivityService userActivityService)
        {
            _authService = authService;
            _userActivityService = userActivityService;
            _databaseContext = context;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(UserCreateModel user)
        {
            CustomValidation();

            var storedUser = await _databaseContext.UserData.FirstOrDefaultAsync(u => u.Email.Equals(user.Email));

            if (storedUser != null)
            {
                throw new HttpResponseException(new UserCreationError("Invalid credentials"),
                    HttpStatusCode.BadRequest);
            }

            var credentials = _authService.CreateCredentials(user.Password);

            var newUser = new UserData
            {
                Email = user.Email,
                PasswordHash = credentials.Hash,
                PasswordSalt = credentials.Salt,
                CreationDate = DateTime.UtcNow,
            };

            await _databaseContext.UserData.AddAsync(newUser);

            await _databaseContext.SaveChangesAsync();

            return Created("/api/user", newUser);
        }


        [HttpPost]
        [Route("password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(UserChangePasswordModel credentials)
        {
            CustomValidation();

            var subjectId = User.GetSubjectId();

            var storedUser = await _databaseContext.UserData.Include(u => u.ProfileImage)
                .FirstOrDefaultAsync(UserIdPredicate(subjectId));

            if (storedUser == null)
            {
                throw new HttpResponseException();
            }

            var isValid = _authService.ValidatePassword(credentials.OldPassword, storedUser.PasswordHash,
                storedUser.PasswordSalt);

            if (!isValid)
            {
                throw new HttpResponseException(new UserChangePasswordError("Invalid credentials"),
                    HttpStatusCode.BadRequest);
            }

            var newCredentials = _authService.CreateCredentials(credentials.Password);

            storedUser.PasswordHash = newCredentials.Hash;
            storedUser.PasswordSalt = newCredentials.Salt;

            await _databaseContext.SaveChangesAsync();

            await _userActivityService.CreateActivityAsync(UserActivityActionName.PasswordChange, storedUser.Id);

            return Ok();
        }

        [HttpGet]
        [Route("info")]
        [Authorize]
        public async Task<IActionResult> GetUserInfo()
        {
            var subjectId = User.GetSubjectId();

            var storedUser = await _databaseContext.UserData
                .Include(u => u.ProfileImage)
                .Include(u => u.UserActivities)
                .ThenInclude(u => u.Action)
                .Include(u => u.UserActivities)
                .ThenInclude(u => u.Collection)
                .Include(u => u.UserActivities)
                .ThenInclude(u => u.Record)
                .FirstOrDefaultAsync(UserIdPredicate(subjectId));

            if (storedUser == null)
            {
                throw new HttpResponseException(new UserInfoError());
            }

            return Ok(storedUser);
        }

        [HttpPatch]
        [Route("info")]
        [Authorize]
        public async Task<IActionResult> UpdateUserInfo([FromBody] JsonPatchDocument<UserInfoUpdateModel>
            userInfo)
        {
            var subjectId = User.GetSubjectId();

            var storedUser = await _databaseContext.UserData.Include(u => u.ProfileImage)
                .FirstOrDefaultAsync(UserIdPredicate(subjectId));

            if (storedUser == null)
            {
                throw new HttpResponseException();
            }

            var userInfoNew = new UserInfoUpdateModel
            {
                DisplayName = storedUser.DisplayName,
                ImageId = storedUser.ProfileImageId,
            };

            userInfo.ApplyTo(userInfoNew, ModelState);
            CustomValidation(userInfoNew);

            if (userInfoNew.ImageId != null)
            {
                var image = await _databaseContext.Image.FirstOrDefaultAsync(u =>
                    u.CreatorId == storedUser.Id && u.Id == userInfoNew.ImageId);

                if (image == null)
                {
                    throw new HttpResponseException(new UserInfoError(), HttpStatusCode.Forbidden);
                }
            }

            storedUser.DisplayName = userInfoNew.DisplayName;
            storedUser.ProfileImageId = userInfoNew.ImageId;

            await _databaseContext.SaveChangesAsync();

            await _userActivityService.CreateActivityAsync(UserActivityActionName.UserUpdate, storedUser.Id);

            return Ok(storedUser);
        }
    }
}