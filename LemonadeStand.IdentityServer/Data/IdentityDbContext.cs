using Microsoft.EntityFrameworkCore;
using LemonadeStand.IdentityServer.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LemonadeStand.Abstractions.Interfaces;

namespace LemonadeStand.IdentityServer.Data
{
  public class IdentityServerDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>, IMigratable
  {
    public DbSet<AspNetRefreshToken> RefreshTokens { get; set; }

    public IdentityServerDbContext(DbContextOptions<IdentityServerDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}