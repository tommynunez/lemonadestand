using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Identity.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LemonadeStand.Identity.Data
{
  public class IdentityDatabaseContext : IdentityDbContext<AppUser, AppRole, int>, IMigratable
  {
    public IdentityDatabaseContext(DbContextOptions<IdentityDatabaseContext> options) : base(options)
    {
    }

    public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
    {
    });

    public IConfiguration? Configuration { get; }
    public DbSet<AppUser> AppUser { get; set; }
    public DbSet<AppRole> AppRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder
          .UseLoggerFactory(loggerFactory)
          .UseSqlServer(Configuration?.GetConnectionString("LemonadeStandDatabase"), b => b.MigrationsAssembly("LemonadeStand"));
      }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      /*https://stackoverflow.com/questions/40703615/the-entity-type-identityuserloginstring-requires-a-primary-key-to-be-defined*/
      /*keys of Identity tables are mapped in OnModelCreating method of IdentityDbContext and 
       * if this method is not called, you will end up getting the error that you got.*/
      base.OnModelCreating(builder);
    }
  }
}
