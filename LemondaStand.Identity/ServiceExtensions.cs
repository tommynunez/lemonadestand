using LemonadeStand.Identity.Controller;
using LemonadeStand.Identity.Data;
using LemonadeStand.Identity.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace LemondaStand.Identity
{
  public static class ServiceExtensions
  {
    public static void AddIdentityService(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddScoped<IAuthenticationController, AuthenticationController>();
      services.AddScoped<IdentityUser<int>, AppUser>();
      services.AddScoped<IdentityRole<int>, AppRole>();
      services.AddDbContext<IdentityDatabaseContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("LemonadeStandDatabase"),
          b => b.MigrationsAssembly("LemonadeStand")),
          ServiceLifetime.Transient);

      services.AddIdentity<AppUser, AppRole>(options =>
      {
        options.User.RequireUniqueEmail = true;
      }).AddEntityFrameworkStores<IdentityDatabaseContext>()
       .AddDefaultTokenProviders();

      services.Configure<IdentityOptions>(options =>
      {
        //password options
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 8;
        options.Password.RequiredUniqueChars = 1;

        //lockout options
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.MaxFailedAccessAttempts = 3;
        options.Lockout.AllowedForNewUsers = true;


        options.User.AllowedUserNameCharacters =
         "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        options.User.RequireUniqueEmail = true;

        //siignin options
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
      });
    }
  }
}
