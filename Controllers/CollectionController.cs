using System.Linq;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using record_keep_api.DBO;

namespace record_keep_api.Controllers
{
    [ApiController]
    [Route("api/collection")]
    [Authorize]
    public class CollectionController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CollectionController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCollections()
        {
            var id = User.GetSubjectId();

            var collections = _context.Collection.Where(collection => collection.OwnerId.ToString().Equals(id));

            return Ok(collections);
        }
    }
}