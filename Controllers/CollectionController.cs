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
using record_keep_api.Models.UserActivity;
using record_keep_api.Services;

namespace record_keep_api.Controllers
{
    [ApiController]
    [Route("api/collection")]
    [Authorize]
    public class CollectionController : CustomControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IUserActivityService _userActivityService;

        public CollectionController(DatabaseContext context, IUserActivityService userActivityService)
        {
            _context = context;
            _userActivityService = userActivityService;
        }

        [HttpGet]
        public IActionResult GetCollections([FromQuery] string name)
        {
            var id = User.GetSubjectId();

            var collections = _context
                .Collection
                .Include(c => c.Image)
                .Include(c => c.Records)
                .Where(collection => collection.OwnerId.ToString().Equals(id) && (string.IsNullOrWhiteSpace(name) ||
                                                                                  collection.Name.ToLower()
                                                                                      .Contains(name.ToLower())))
                .ToList()
                .Select(c => new CollectionResponseModel
                {
                    Id = c.Id,
                    Description = c.Description,
                    Name = c.Name,
                    CreationDate = c.CreationDate,
                    RecordCount = c.Records.Count,
                    Image = c.Image,
                    ImageId = c.ImageId,
                    OwnerId = c.OwnerId
                });

            return Ok(collections);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCollection(int id)
        {
            CustomValidation();

            var userId = User.GetSubjectId();

            var user = await _context.UserData.FirstOrDefaultAsync(UserIdPredicate(userId));

            if (user == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.Unauthorized);
            }

            var collection = await _context.Collection
                .Include(c => c.Image)
                .Include(c => c.Records)
                .FirstOrDefaultAsync(c => c.Id == id && c.OwnerId == user.Id);

            if (collection == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.NotFound);
            }

            var customCollection = new CollectionResponseModel
            {
                Id = collection.Id,
                Description = collection.Description,
                Name = collection.Name,
                CreationDate = collection.CreationDate,
                RecordCount = collection.Records.Count,
                Image = collection.Image,
                ImageId = collection.ImageId,
                OwnerId = collection.OwnerId
            };

            return Ok(customCollection);
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

            await _userActivityService.CreateActivityAsync(UserActivityActionName.CollectionCreate, user.Id,
                collection);

            return Created("/api/collection", collection);
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

            var collection = await _context.Collection.FirstOrDefaultAsync(c => c.Id == id && c.OwnerId == user.Id);

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

            await _userActivityService.CreateActivityAsync(UserActivityActionName.CollectionUpdate, user.Id,
                collection);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCollection(int id, [FromQuery] int? destinationId)
        {
            CustomValidation();

            var userId = User.GetSubjectId();

            var user = await _context.UserData.FirstOrDefaultAsync(UserIdPredicate(userId));

            if (user == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.Unauthorized);
            }

            var originCollection = await _context
                .Collection
                .Include(c => c.Image)
                .FirstOrDefaultAsync(c => c.Id == id && c.OwnerId == user.Id);

            if (originCollection == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.NotFound);
            }

            if (destinationId == null)
            {
                _context.Collection.Remove(originCollection);

                await _context.SaveChangesAsync();

                await _userActivityService.CreateActivityAsync(UserActivityActionName.CollectionDelete, user.Id);

                return Ok();
            }

            var destinationCollection = await _context
                .Collection
                .Include(c => c.Image)
                .FirstOrDefaultAsync(c => c.Id == destinationId && c.OwnerId == user.Id);

            if (destinationCollection == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.NotFound);
            }

            var originRecords = _context.Record.Where(r => r.CollectionId == originCollection.Id);

            foreach (var collectionRecord in originRecords)
            {
                collectionRecord.CollectionId = destinationCollection.Id;
            }

            _context.Record.UpdateRange(originRecords);

            _context.Collection.Remove(originCollection);

            await _context.SaveChangesAsync();

            await _userActivityService.CreateActivityAsync(UserActivityActionName.CollectionDeleteWithMove, user.Id,
                destinationCollection);

            return Ok();
        }
    }
}