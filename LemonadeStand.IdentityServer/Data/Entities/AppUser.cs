using Microsoft.AspNetCore.Identity;

namespace LemonadeStand.IdentityServer.Data.Entities
{
  public class AppUser : IdentityUser<Guid>
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string NormalizePhone { get; set; }

    public virtual ICollection<AspNetRefreshToken> RefreshTokens { get; set; } = new List<AspNetRefreshToken>();

    public AppUser()
    {
    }
  }
}