using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LemonadeStand.IdentityServer.Common.Models
{
  public class ResetPasswordDTO
  {
    [DataMember, Required]
    public required string Email { get; set; }
    [DataMember, Required]
    public required string Token { get; set; }
    [DataMember, Required]
    public required string Password { get; set; }
    [DataMember, Required]
    public required string ConfirmPassword {  get; set; }
  }
}
