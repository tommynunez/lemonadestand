using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LemondaStand.Identity.DataTransferObjects
{
  [DataContract]
  public class ForgotPasswordDto
  {
    [DataMember]
    public string Email { get; set; }
  }
}
