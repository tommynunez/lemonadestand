using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LemonadeStand.IdentityServer.Models;

namespace LemonadeStand.IdentityServer.Data
{
  public class IdentityServerDbContext : IdentityDbContext<AppUser>
  {
    public IdentityServerDbContext()
    {

    }

    public override void OnModelCreating(ModelBuilder builder)
    {

    }
  }
}