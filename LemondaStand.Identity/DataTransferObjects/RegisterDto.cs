using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LemondaStand.Identity.DataTransferObjects
{
  [DataContract]
  public class RegisterDto
  {
    [DataMember, Required]
    [RegularExpression(@"^[a-zA-Z]+$",
         ErrorMessage = "Characters are not allowed.")]
    public string FirstName { get; set; }

    [DataMember, Required]
    [RegularExpression(@"^[a-zA-Z]+$",
         ErrorMessage = "Characters are not allowed.")]
    public string LastName { get; set; }

    [DataMember, Required, EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [DataMember, Required]
    [RegularExpression(@"^\d{10}$",
         ErrorMessage = "Expected format is 1234567890")]
    public string PhoneNumber { get; set; }

    [DataMember, Required]
    public string Password { get; set; }

    [DataMember, Required]
    public string ConfirmedPassword { get; set; }
  }
}
