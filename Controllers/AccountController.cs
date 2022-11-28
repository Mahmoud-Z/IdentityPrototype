using IdentityTest.Dtos;
using IdentityTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(UserManager<Users> userManager, SignInManager<Users> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Users newUser = new Users();
            newUser.UserName = input.Username;
            newUser.FirstName = input.FirstName;
            var result = await _userManager.CreateAsync(newUser, input.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _signInManager.PasswordSignInAsync(input.Username, input.Password, false, false);
            if (!result.Succeeded)
            {
                return Unauthorized(input);
            }
            return Accepted();
        }
    }
}
