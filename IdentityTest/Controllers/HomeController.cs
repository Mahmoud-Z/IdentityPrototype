using IdentityTest.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HomeController : ControllerBase
    {
        private readonly SeedingDbTestContext _context;
        public HomeController(SeedingDbTestContext context)
        {
            _context = context;
        }
        [HttpPost("GetAll")]
        public async Task<List<Document>> Register()
        {
            return _context.Documents.ToList();
        }
    }
}
