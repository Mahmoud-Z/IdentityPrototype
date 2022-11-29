using IdentityTest.Dtos;
using IdentityTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace IdentityTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUserStore<Users> _userStore;
        private readonly IUserEmailStore<Users> _emailStore;

        public AccountController(
            UserManager<Users> userManager,
            SignInManager<Users> signInManager,
            ILogger<AccountController> logger,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _configuration = configuration;
            _emailStore = GetEmailStore();
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Users newUser = new Users();
            newUser.UserName = input.Username;
            newUser.FirstName = input.FirstName;
            var result = await _userManager.CreateAsync(newUser, input.Password);41
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
            
            // Deletes the cookies
            Response.Cookies.Delete(".AspNetCore.Identity.Application");
           
            if (!result.Succeeded)
            {
                return Unauthorized(input);
            }
            var token = GetToken();
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo });
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("User logged out.");
            
        }




        [HttpPost("RegisterIdnetity")]
        public async Task<IActionResult> RegisterIdnetity(UserDto input)
        {
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, input.Username, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, input.Username, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, input.Password);

                if (result.Succeeded)
                {
                    return Ok("User created a new account with password.");

                    
                }
            }

            // If we got this far, something failed, redisplay form
            return NoContent();
        }






        private IUserEmailStore<Users> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<Users>)_userStore;
        }






        private Users CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Users>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Users)}'. " +
                    $"Ensure that '{nameof(Users)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }




        private JwtSecurityToken GetToken()
        {

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: new List<Claim>(),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;


        }
    }
}
