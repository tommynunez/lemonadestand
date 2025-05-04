using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LemonadeStand.IdentityServer.Common.Models
{
  [DataContract]
  public class SignInDTO
  {
    [DataMember]
    [Required(ErrorMessage = "Email is required")]
    public required string Email {  get; set; }

    [DataMember]
    [Required(ErrorMessage = "Password is required")]
    public required string Password { get; set; }
  }
}
