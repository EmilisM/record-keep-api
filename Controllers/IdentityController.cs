using Microsoft.AspNetCore.Mvc;
using record_keep_api.DBO;

namespace record_keep_api.Controllers
{
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public IdentityController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.RecordType);
        }
    }
}