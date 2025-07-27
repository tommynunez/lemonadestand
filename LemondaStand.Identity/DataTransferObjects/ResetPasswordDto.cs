using System.Runtime.Serialization;

namespace LemondaStand.Identity.DataTransferObjects
{
  [DataContract]
  public class ResetPasswordDto
  {
    [DataMember]
    public string Email { get; set; }

    [DataMember]
    public string Token { get; set; }
    
    [DataMember]
    public string Password { get; set; }
    
    [DataMember]
    public string ConfirmedPassword { get; set; }
  }
}
