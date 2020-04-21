﻿using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using record_keep_api.DBO;
using record_keep_api.Error;
using record_keep_api.Models.Image;
using record_keep_api.Services;

namespace record_keep_api.Controllers
{
    [ApiController]
    [Route("api/image")]
    public class ImageController : CustomControllerBase
    {
        private readonly IImageService _imageService;
        private readonly DatabaseContext _context;

        public ImageController(IImageService imageService, DatabaseContext databaseContext, DatabaseContext context)
        {
            _imageService = imageService;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllImages()
        {
            CustomValidation();

            var subjectId = User.GetSubjectId();

            var storedUsed = await _context.UserData.FirstOrDefaultAsync(UserIdPredicate(subjectId));

            if (storedUsed == null)
            {
                throw new HttpResponseException();
            }

            var images = _context.Image.Where(image => image.CreatorId == storedUsed.Id);

            return Ok(images);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateNewImage(ImageCreateModel model)
        {
            CustomValidation();

            var subjectId = User.GetSubjectId();

            var storedUsed = await _context.UserData.FirstOrDefaultAsync(UserIdPredicate(subjectId));

            if (storedUsed == null)
            {
                throw new HttpResponseException();
            }

            var image = new Image
            {
                Data =
                    await _imageService.GetImageCroppedAsync(model.Data, model.X, model.Y, model.Width, model.Height),
                CreatorId = storedUsed.Id
            };

            await _context.Image.AddAsync(image);

            await _context.SaveChangesAsync();

            return Created("/api/image", image);
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> UpdateImage(int id, [FromBody] ImageUpdateModel model)
        {
            CustomValidation();

            var subjectId = User.GetSubjectId();

            var storedUsed = await _context.UserData.FirstOrDefaultAsync(UserIdPredicate(subjectId));

            if (storedUsed == null)
            {
                throw new HttpResponseException();
            }

            var image = await _context.Image.FirstOrDefaultAsync(i => i.Id == id && i.CreatorId == storedUsed.Id);

            if (image == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.NotFound);
            }

            image.Data =
                await _imageService.GetImageCroppedAsync(model.Data, model.X, model.Y, model.Width, model.Height);

            return Ok(image);
        }
    }
}