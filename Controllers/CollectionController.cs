using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using record_keep_api.DBO;
using record_keep_api.Error;
using record_keep_api.Models.Collection;

namespace record_keep_api.Controllers
{
    [ApiController]
    [Route("api/collection")]
    [Authorize]
    public class CollectionController : CustomControllerBase
    {
        private readonly DatabaseContext _context;

        public CollectionController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCollections()
        {
            var id = User.GetSubjectId();

            var collections = _context
                .Collection
                .Include(c => c.Image)
                .Where(collection => collection.OwnerId.ToString().Equals(id));

            return Ok(collections);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCollection(int id)
        {
            var collection = await _context.Collection.Include(c => c.Image).FirstOrDefaultAsync(c => c.Id == id);

            if (collection == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.NotFound);
            }

            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollection(CreateCollectionModel model)
        {
            CustomValidation();

            var id = User.GetSubjectId();

            var user = await _context.UserData.FirstOrDefaultAsync(UserIdPredicate(id));

            if (user == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.Unauthorized);
            }

            var collection = new Collection
            {
                OwnerId = user.Id,
                Name = model.Name,
                CreationDate = DateTime.UtcNow
            };

            await _context.Collection.AddAsync(collection);

            await _context.SaveChangesAsync();

            return Created("/api/user", collection);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCollection(int id, [FromBody] JsonPatchDocument<UpdateCollectionModel>
            model)
        {
            CustomValidation();

            var userId = User.GetSubjectId();

            var user = await _context.UserData.FirstOrDefaultAsync(UserIdPredicate(userId));

            if (user == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.Unauthorized);
            }

            var collection = await _context.Collection.FirstOrDefaultAsync(c => c.Id == id);

            if (collection == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.NotFound);
            }

            var newCollection = new UpdateCollectionModel
            {
                Name = collection.Name,
                Description = collection.Description,
                ImageId = collection.ImageId
            };

            model.ApplyTo(newCollection, ModelState);
            CustomValidation(newCollection);

            if (newCollection.ImageId != null)
            {
                var image = await _context.Image.FirstOrDefaultAsync(u =>
                    u.CreatorId == user.Id && u.Id == newCollection.ImageId);

                if (image == null)
                {
                    throw new HttpResponseException(null, HttpStatusCode.Forbidden);
                }
            }

            collection.Name = newCollection.Name;
            collection.Description = newCollection.Description;
            collection.ImageId = newCollection.ImageId;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}