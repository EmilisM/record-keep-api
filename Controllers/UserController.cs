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
using record_keep_auth_service;

namespace record_keep_api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : CustomControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IAuthService _authService;

        public UserController(DatabaseContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(UserCreateModel user)
        {
            CustomValidation();

            var storedUser = await _context.UserData.FirstOrDefaultAsync(u => u.Email.Equals(user.Email));

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

            await _context.UserData.AddAsync(newUser);

            await _context.SaveChangesAsync();

            return Created("/api/user/create", newUser);
        }


        [HttpPost]
        [Route("password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(UserChangePasswordModel credentials)
        {
            CustomValidation();

            var subjectId = User.GetSubjectId();

            var storedUser = await _context.UserData.Include(u => u.ProfileImage)
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

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("info")]
        [Authorize]
        public async Task<IActionResult> GetUserInfo()
        {
            var subjectId = User.GetSubjectId();

            var storedUser = await _context.UserData.Include(u => u.ProfileImage)
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

            var storedUser = await _context.UserData.Include(u => u.ProfileImage)
                .FirstOrDefaultAsync(UserIdPredicate(subjectId));

            if (storedUser == null)
            {
                throw new HttpResponseException(new UserInfoError());
            }

            var userInfoNew = new UserInfoUpdateModel
            {
                DisplayName = storedUser.DisplayName,
                ImageId = storedUser.ProfileImageId,
            };

            userInfo.ApplyTo(userInfoNew, ModelState);
            CustomValidation(userInfoNew);

            storedUser.DisplayName = userInfoNew.DisplayName;
            storedUser.ProfileImageId = userInfoNew.ImageId;

            await _context.SaveChangesAsync();

            return Ok(storedUser);
        }
    }
}