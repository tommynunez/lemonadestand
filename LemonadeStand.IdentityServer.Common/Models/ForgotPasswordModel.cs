using System.Runtime.Serialization;

namespace LemonadeStand.IdentityServer.Common.Models
{
  public class ForgotPasswordModel
  {
    [DataMember]
    public string Email {  get; set; }
  }
}
