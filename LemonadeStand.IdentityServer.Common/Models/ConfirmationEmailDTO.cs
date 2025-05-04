using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LemonadeStand.IdentityServer.Common.Models
{
  public class ConfirmationEmailDTO
  {
    [DataMember, Required]
    public required string Email { get; set; }
    [DataMember, Required]
    public required string Token { get; set; }
  }
}
