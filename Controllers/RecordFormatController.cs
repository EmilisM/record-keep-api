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
    [Route("api/record/format")]
    [AllowAnonymous]
    public class RecordFormatController : CustomControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public RecordFormatController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public IActionResult GetRecordFormats()
        {
            var recordFormats = _databaseContext.RecordFormat;

            return Ok(recordFormats);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRecordFormat(int id)
        {
            var recordFormat = await _databaseContext
                .RecordFormat
                .FirstOrDefaultAsync((rt => rt.Id == id));

            if (recordFormat == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.NotFound);
            }

            return Ok(recordFormat);
        }
    }
}