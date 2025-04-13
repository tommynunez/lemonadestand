using System.ComponentModel.DataAnnotations;

namespace LemonadeStand.IdentityServer
{
    public class SigninRequest
    {
        [Required(ErrorMessage = "Please enter a username")]
        public string? Username {  get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        public string? Password { get; set; }
    }
}