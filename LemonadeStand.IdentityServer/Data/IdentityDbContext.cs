using Microsoft.EntityFrameworkCore;
using LemonadeStand.IdentityServer.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LemonadeStand.IdentityServer.Data
{
  public class IdentityServerDbContext : IdentityDbContext<AppUser<Guid>, IdentityRole<Guid>, Guid>
  {
    public IdentityServerDbContext(DbContextOptions<IdentityServerDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

    }
  }
}