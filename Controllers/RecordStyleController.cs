using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using record_keep_api.DBO;
using record_keep_api.Error;

namespace record_keep_api.Controllers
{
    [ApiController]
    [Route("/api/record/style")]
    [Authorize]
    public class RecordStyleController : CustomControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public RecordStyleController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecordStyles([FromQuery] int? recordId, [FromQuery] int? styleId)
        {
            CustomValidation();

            var userId = User.GetSubjectId();

            var storedUser = await _databaseContext.UserData.FirstOrDefaultAsync(UserIdPredicate(userId));

            if (storedUser == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.Unauthorized);
            }

            var recordStyles = _databaseContext.RecordStyle
                .Include(rs => rs.Record)
                .Include(rs => rs.Style)
                .ThenInclude(s => s.Genre)
                .Where(rs =>
                    rs.Record.OwnerId == storedUser.Id && recordId == null ||
                    rs.RecordId == recordId && styleId == null || rs.StyleId == styleId);

            return Ok(recordStyles);
        }
    }
}