using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using record_keep_api.DBO;

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
        public IActionResult GetStyles()
        {
            var styles = _databaseContext.Styles;

            return Ok(styles);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStyle(int id)
        {
            var styles = _databaseContext
                .Genres
                .FirstOrDefaultAsync(style => style.Id == id);

            return Ok(styles);
        }
    }
}