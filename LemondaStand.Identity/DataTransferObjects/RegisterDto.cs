using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
    public string UserName { get; set; }
    
    [DataMember, Required]
    public string PhoneNumber { get; set; }

    [DataMember, Required]
    public string Password { get; set; }

    [DataMember, Required]
    public string ConfirmedPassword { get; set; }
  }
}
