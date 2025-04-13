using Microsoft.AspNetCore.Identity;

namespace LemonadeStand.IdentityServer.Data.Entities
{
  public class AppUser : IdentityUser<Guid>
  {
    public AppUser()
    {

    }
  }
}