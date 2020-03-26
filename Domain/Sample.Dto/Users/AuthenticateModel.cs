using System.ComponentModel.DataAnnotations;

namespace Sample.Dto.Users
{
    public class AuthenticateModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}