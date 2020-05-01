using System.Linq;
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
    [Route("/api/style")]
    [AllowAnonymous]
    public class StyleController : CustomControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public StyleController(DatabaseContext context)
        {
            _databaseContext = context;
        }

        [HttpGet]
        public IActionResult GetStyles([FromQuery] int? genreId)
        {
            var styles = _databaseContext.Style
                .Include(s => s.Genre)
                .Where(s => genreId == null || s.GenreId == genreId);

            return Ok(styles);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStyle(int id)
        {
            var styles = await _databaseContext
                .Style.Include(s => s.Genre)
                .FirstOrDefaultAsync(style => style.Id == id);

            if (styles == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.NotFound);
            }

            return Ok(styles);
        }
    }
}