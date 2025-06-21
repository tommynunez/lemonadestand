
using Microsoft.AspNetCore.Identity;

namespace LemondaStand.Identity.Data.Models
{
  public partial class AppUser : IdentityUser<int>
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NormalizedPhoneNumber { get; set; }

    public virtual ICollection<IdentityToken> IdentityTokens { get; set; }

    public AppUser()
    {
      IdentityTokens = new List<IdentityToken>();
    }
  }
}
