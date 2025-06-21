using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LemondaStand.Identity.DataTransferObjects
{
  [DataContract]
  public class RegisterDto
  {
    [DataMember, Required]
    public string FirstName { get; set; }

    [DataMember, Required]
    public string LastName { get; set; }

    [DataMember, Required]
    public string Email { get; set; }

    [DataMember, Required]
    public string PhoneNumber { get; set; }

    [DataMember, Required]
    public string Password { get; set; }

    [DataMember, Required]
    public string ConfirmedPassword { get; set; }
  }
}
