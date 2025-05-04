using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LemonadeStand.IdentityServer.Common.Models
{
  public class RegisterDTO
  {
    [DataMember, Required]
    public required string Email { get; set; }
    [DataMember, Required]
    public required string Password { get; set; }
    [DataMember, Required]
    public required string ConfirmPassword { get; set; }
  }
}
