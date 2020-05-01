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
        public async Task<IActionResult> GetGenre(int id)
        {
            var genres = await _databaseContext
                .Genre
                .FirstOrDefaultAsync(genre => genre.Id == id);

            if (genres == null)
            {
                throw new HttpResponseException(null, HttpStatusCode.NotFound);
            }

            return Ok(genres);
        }
    }
}