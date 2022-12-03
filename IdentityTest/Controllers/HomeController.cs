using IdentityTest.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class HomeController : ControllerBase
    {
        private readonly SeedingDbTestContext _context;
        public HomeController(SeedingDbTestContext context)
        {
            _context = context;
        }
        [Authorize(AuthenticationSchemes = "Identity.Application")]
        
        [HttpGet("GetAllCookies")]
        public async Task<List<Document>> RegisterCookies()
        {
            return _context.Documents.ToList();
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllJwt")]
        public async Task<List<Document>> RegisterJwt()
        {
            return _context.Documents.ToList();
        }

     

    }
}
