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
using record_keep_api.Models.Record;
using record_keep_api.Models.UserActivity;
using record_keep_api.Services;

namespace record_keep_api.Controllers
{
    [ApiController]
    [Route("api/record")]
    [Authorize]
    public class RecordController : CustomControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IUserActivityService _userActivityService;

        public RecordController(DatabaseContext databaseContext, IUserActivityService userActivityService)
        {
            _databaseContext = databaseContext;
            _userActivityService = userActivityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecords([FromQuery] string collectionId, [FromQuery] string query)
        {
            var userId = User.GetSubjectId();

            var user = await _databaseContext.UserData.FirstOrDefaultAsync(UserIdPredicate(userId));

            if (user == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.Unauthorized);
            }

            var records = _databaseContext.Record
                .Include(r => r.Image)
                .Include(r => r.RecordType)
                .Include(r => r.RecordFormat)
                .Include(r => r.RecordStyle)
                .ThenInclude(rs => rs.Style)
                .ThenInclude(s => s.Genre)
                .Where(record => record.OwnerId == user.Id && (string.IsNullOrWhiteSpace(collectionId) ||
                                                               record.CollectionId.ToString() == collectionId) &&
                                 (string.IsNullOrWhiteSpace(query) ||
                                  record.Artist.ToLower().Contains(query.ToLower()) ||
                                  record.Name.ToLower().Contains(query.ToLower())));

            return Ok(records);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRecord(int id)
        {
            CustomValidation();

            var userId = User.GetSubjectId();

            var user = await _databaseContext.UserData.FirstOrDefaultAsync(UserIdPredicate(userId));

            if (user == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.Unauthorized);
            }

            var record = await _databaseContext.Record
                .Include(r => r.Image)
                .Include(r => r.RecordType)
                .Include(r => r.RecordFormat)
                .Include(r => r.RecordStyle)
                .ThenInclude(rs => rs.Style)
                .ThenInclude(s => s.Genre)
                .FirstOrDefaultAsync(r => r.OwnerId == user.Id && r.Id == id);

            if (record == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.NotFound);
            }

            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecord(CreateRecordModel model)
        {
            CustomValidation();

            var userId = User.GetSubjectId();

            var user = await _databaseContext.UserData.FirstOrDefaultAsync(UserIdPredicate(userId));

            if (user == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.Unauthorized);
            }

            var storedCollection = await
                _databaseContext.Collection.FirstOrDefaultAsync(c =>
                    c.Id == model.CollectionId && c.OwnerId == user.Id);

            var storedRecordType =
                await _databaseContext.RecordType
                    .FirstOrDefaultAsync(rt => rt.Id == model.RecordTypeId);

            var storedRecordFormat = await _databaseContext.RecordFormat.FirstOrDefaultAsync(
                rt => rt.Id == model.RecordFormatId);

            var storedImage =
                await _databaseContext.Image
                    .FirstOrDefaultAsync(i => i.Id == model.ImageId && i.CreatorId == user.Id);

            var storedStyles = _databaseContext.Style.Where(s => model.StyleIds.Contains(s.Id));

            if (storedCollection == null || storedRecordType == null || storedStyles == null ||
                storedRecordFormat == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.BadRequest);
            }

            var newRecord = new Record
            {
                Name = model.Name,
                Artist = model.Artist,
                Description = model.Description,
                CollectionId = storedCollection.Id,
                OwnerId = user.Id,
                CreationDate = DateTime.UtcNow,
                ImageId = storedImage?.Id,
                RecordTypeId = storedRecordType.Id,
                RecordFormatId = storedRecordFormat.Id,
                Label = model.Label,
                Year = model.Year,
                RecordLength = model.RecordLength,
            };

            await _databaseContext.Record.AddAsync(newRecord);

            var newRecordStyles = storedStyles.Select(s => new RecordStyle
            {
                Record = newRecord,
                StyleId = s.Id
            });

            await _databaseContext.RecordStyle.AddRangeAsync(newRecordStyles);

            await _databaseContext.SaveChangesAsync();

            await _userActivityService.CreateActivityAsync(UserActivityActionName.RecordCreate, user.Id,
                record: newRecord);

            return Created("/api/record", newRecord);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRecord([FromQuery] int[] id)
        {
            CustomValidation();

            var userId = User.GetSubjectId();

            var user = await _databaseContext.UserData.FirstOrDefaultAsync(UserIdPredicate(userId));

            if (user == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.Unauthorized);
            }

            var record =
                _databaseContext.Record.Where(r => id.Contains(r.Id) && r.OwnerId == user.Id).ToList();

            if (id.Length != record.Count)
            {
                throw new HttpResponseException(null, HttpStatusCode.NotFound);
            }

            _databaseContext.Record.RemoveRange(record);

            await _databaseContext.SaveChangesAsync();

            await _userActivityService.CreateActivityAsync(UserActivityActionName.RecordDelete, user.Id);

            return Ok();
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRecord(int id, [FromBody] JsonPatchDocument<UpdateRecordModel> model)
        {
            CustomValidation();

            var userId = User.GetSubjectId();

            var user = await _databaseContext.UserData.FirstOrDefaultAsync(UserIdPredicate(userId));

            if (user == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.Unauthorized);
            }

            var recordToUpdate = await _databaseContext.Record
                .Include(r => r.Image)
                .Include(r => r.RecordType)
                .Include(r => r.RecordFormat)
                .FirstOrDefaultAsync(r => r.Id == id && r.OwnerId == user.Id);

            var recordStyles = _databaseContext.RecordStyle
                .Include(rs => rs.Style)
                .Where(r => r.RecordId == id);

            if (recordToUpdate == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.NotFound);
            }

            var newModel = new UpdateRecordModel
            {
                Artist = recordToUpdate.Artist,
                Name = recordToUpdate.Name,
                Description = recordToUpdate.Description,
                Label = recordToUpdate.Label,
                Year = recordToUpdate.Year,
                RecordTypeId = recordToUpdate.RecordTypeId,
                RecordFormatId = recordToUpdate.RecordFormatId,
                ImageId = recordToUpdate.ImageId,
                StyleIds = recordStyles.Select(rs => rs.StyleId).ToArray(),
                Rating = recordToUpdate.Rating,
                RecordLength = recordToUpdate.RecordLength
            };

            model.ApplyTo(newModel, ModelState);
            CustomValidation(newModel);

            if (newModel.ImageId != null)
            {
                var image = await _databaseContext.Image.FirstOrDefaultAsync(i =>
                    i.Id == newModel.ImageId && i.CreatorId == user.Id);

                if (image == null)
                {
                    throw new HttpResponseException(null, HttpStatusCode.Forbidden);
                }
            }

            var newRecordType = await _databaseContext.RecordType
                .FirstOrDefaultAsync(rt => rt.Id == newModel.RecordTypeId);

            var newRecordFormat = await _databaseContext.RecordFormat
                .FirstOrDefaultAsync(rt => rt.Id == newModel.RecordFormatId);

            var newStyles = _databaseContext.Style
                .Where(s => newModel.StyleIds.Contains(s.Id));

            var firstNewStyle = await newStyles.FirstOrDefaultAsync();

            if (newRecordType == null || newStyles.Count() != newModel.StyleIds.Length ||
                firstNewStyle == null || !newStyles.All(s => s.GenreId == firstNewStyle.GenreId) ||
                newRecordFormat == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.BadRequest);
            }

            //TODO: Avoid dirty update
            _databaseContext.RecordStyle.RemoveRange(recordStyles);

            var newRecordStyles = newStyles.Select(s => new RecordStyle
            {
                RecordId = recordToUpdate.Id,
                StyleId = s.Id
            });

            await _databaseContext.RecordStyle.AddRangeAsync(newRecordStyles);

            //TODO: Automapper
            recordToUpdate.Artist = newModel.Artist;
            recordToUpdate.Name = newModel.Name;
            recordToUpdate.Description = newModel.Description;
            recordToUpdate.Label = newModel.Label;
            recordToUpdate.Year = newModel.Year;
            recordToUpdate.Rating = newModel.Rating;
            recordToUpdate.RecordLength = newModel.RecordLength;

            recordToUpdate.ImageId = newModel.ImageId;
            recordToUpdate.RecordTypeId = newRecordType.Id;
            recordToUpdate.RecordFormatId = newRecordFormat.Id;

            await _databaseContext.SaveChangesAsync();

            await _userActivityService.CreateActivityAsync(UserActivityActionName.RecordUpdate, user.Id,
                record: recordToUpdate);

            return Ok(recordToUpdate);
        }
    }
}