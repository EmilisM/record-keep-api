using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using record_keep_api.DBO;
using record_keep_api.Error;

namespace record_keep_api.Controllers
{
    [ApiController]
    [Route("api/record/type")]
    [AllowAnonymous]
    public class RecordTypeController : CustomControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public RecordTypeController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public IActionResult GetRecordTypes()
        {
            var recordTypes = _databaseContext.RecordType;

            return Ok(recordTypes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRecordType(int id)
        {
            var recordType = await _databaseContext
                .RecordType
                .FirstOrDefaultAsync((rt => rt.Id == id));

            if (recordType == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.NotFound);
            }

            return Ok(recordType);
        }
    }
}