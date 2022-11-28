using System.ComponentModel.DataAnnotations;

namespace IdentityTest.Dtos
{
    public class UserDto
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        [Required]
        [StringLength(15,ErrorMessage = "15 is the max")]
        public string Password { get; set; }
    }
}
