using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LemondaStand.Identity.DataTransferObjects
{
  [DataContract]
  public class ConfirmationEmailDto
  {
    [DataMember, Required]
    public string Email { get; set; }
    [DataMember, Required]
    public string Token { get; set; }
  }
}
