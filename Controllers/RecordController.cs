using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using record_keep_api.DBO;
using record_keep_api.Error;
using record_keep_api.Models.Record;

namespace record_keep_api.Controllers
{
    [ApiController]
    [Route("api/record")]
    [Authorize]
    public class RecordController : CustomControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public RecordController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecords()
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
                .Where(record => record.OwnerId == user.Id);

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
                .FirstOrDefaultAsync(r => r.OwnerId == user.Id);

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

            var storedImage =
                await _databaseContext.Image
                    .FirstOrDefaultAsync(i => i.Id == model.ImageId && i.CreatorId == user.Id);

            var storedStyles = _databaseContext.Style.Where(s => model.StyleIds.Contains(s.Id));

            if (storedCollection == null || storedRecordType == null || storedStyles == null)
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
                Label = model.Label,
                Year = model.Year,
            };

            await _databaseContext.Record.AddAsync(newRecord);

            var newRecordStyles = storedStyles.Select(s => new RecordStyles
            {
                Record = newRecord,
                StyleId = s.Id
            });

            await _databaseContext.RecordStyles.AddRangeAsync(newRecordStyles);

            await _databaseContext.SaveChangesAsync();

            return Created("/api/record", newRecord);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            CustomValidation();

            var userId = User.GetSubjectId();

            var user = await _databaseContext.UserData.FirstOrDefaultAsync(UserIdPredicate(userId));

            if (user == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.Unauthorized);
            }

            var record = await _databaseContext.Record.FirstOrDefaultAsync(r => r.Id == id && r.OwnerId == user.Id);

            if (record == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.NotFound);
            }

            _databaseContext.Record.Remove(record);

            await _databaseContext.SaveChangesAsync();

            return Ok();
        }
    }
}