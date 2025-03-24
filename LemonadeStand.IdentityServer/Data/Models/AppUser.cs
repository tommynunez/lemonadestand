using Microsoft.AspNetCore.Identity;

namespace LemonadeStand.IdentityServer.Data.Models
{
  public class AppUser<T> : IdentityUser<Guid>
  {
    public AppUser()
    {

    }
  }
}