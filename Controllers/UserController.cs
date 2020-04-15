using System;
using System.Net;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using record_keep_api.DBO;
using record_keep_api.Error;
using record_keep_api.Models;
using record_keep_api.Models.Error;
using record_keep_auth_service;

namespace record_keep_api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IAuthService _authService;

        public UserController(DatabaseContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(UserRequestModel user)
        {
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

        [HttpGet]
        [Route("info")]
        [Authorize]
        public async Task<IActionResult> GetUserInfo()
        {
            var subjectId = User.GetSubjectId();

            var storedUser = await _context.UserData.Include(u => u.Image)
                .FirstOrDefaultAsync(u => u.Id.ToString().Equals(subjectId));

            if (storedUser == null)
            {
                throw new HttpResponseException(new UserInfoError());
            }

            return Ok(storedUser);
        }
    }
}