using Microsoft.AspNetCore.Identity;

namespace IdentityTest.Models
{
    public class Users : IdentityUser
    {
        public string FirstName { get; set; }
    }
}
