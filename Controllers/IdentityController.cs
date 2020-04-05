using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using record_keep_api.DBO;

namespace record_keep_api.Controllers
{
    [ApiController]
    [Route("identity")]
    [Authorize]
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
            return Ok(User.Claims.Select(claim => new
                {claim.Issuer, claim.OriginalIssuer, claim.Type, claim.Value, claim.ValueType}));
        }
    }
}