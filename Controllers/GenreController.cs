using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using record_keep_api.DBO;

namespace record_keep_api.Controllers
{
    [ApiController]
    [Route("api/genre")]
    [AllowAnonymous]
    public class GenreController : CustomControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public GenreController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            var genres = _databaseContext.Genre;

            return Ok(genres);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetGenre(int id)
        {
            var genres = _databaseContext
                .Genre
                .FirstOrDefaultAsync(genre => genre.Id == id);

            return Ok(genres);
        }
    }
}