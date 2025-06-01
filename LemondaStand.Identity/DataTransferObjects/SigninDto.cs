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
  public class SigninDto
  {
    [DataMember, Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
    [DataMember, Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
  }
}
