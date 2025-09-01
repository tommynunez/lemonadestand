using LemonadeStand.Identity.Data.Models;
using LemonadeStand.Identity.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LemonadeStand.Abstractions.Extensions
{
  public static class SeedAdministratorUserExtension
  {
    public static void UseSeedAdministratorUserExtension(this IApplicationBuilder applicationBuilder, IServiceProvider serviceProvider, IConfiguration configuration)
    {
      IOptions<AdministratorOptions> administratorOptions = LoadOptions(serviceProvider);
      if (!administratorOptions.Value.ShouldSeedData)
      {
        return;
      }

      EnsureAdministratorOptionsAreValid(administratorOptions);

      var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
      var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

      EnsureAdministratorUserExists(administratorOptions, userManager);
      EnsureAdministratorRoleExists(roleManager);
    }

    private static IOptions<AdministratorOptions> LoadOptions(IServiceProvider serviceProvider)
    {
      var options = serviceProvider.GetRequiredService<IOptions<AdministratorOptions>>();
      if (options == null)
      {
        throw new ArgumentNullException(nameof(options), "Administrator configuration value is missing or null.");
      }

      return options;
    }

    private static void EnsureAdministratorOptionsAreValid(IOptions<AdministratorOptions> administratorOptions)
    {
      if (String.IsNullOrEmpty(administratorOptions.Value.FirstName))
      {
        throw new ArgumentNullException(nameof(administratorOptions.Value.FirstName), "Administrator first name configuration value is missing or null.");
      }

      if (String.IsNullOrEmpty(administratorOptions.Value.LastName))
      {
        throw new ArgumentNullException(nameof(administratorOptions.Value.LastName), "Administrator last name configuration value is missing or null.");
      }

      if (String.IsNullOrEmpty(administratorOptions.Value.UserName))
      {
        throw new ArgumentNullException(nameof(administratorOptions.Value.UserName), "Administrator username configuration value is missing or null.");
      }

      if (String.IsNullOrEmpty(administratorOptions.Value.EmailAddress))
      {
        throw new ArgumentNullException(nameof(administratorOptions.Value.EmailAddress), "Administrator email configuration value is missing or null.");
      }

      if (String.IsNullOrEmpty(administratorOptions.Value.Password))
      {
        throw new ArgumentNullException(nameof(administratorOptions.Value.Password), "Administrator password configuration value is missing or null.");
      }

      if (String.IsNullOrEmpty(administratorOptions.Value.PhoneNumber))
      {
        throw new ArgumentNullException(nameof(administratorOptions.Value.PhoneNumber), "Administrator phone number configuration value is missing or null.");
      }
    }

    private static void EnsureAdministratorUserExists(IOptions<AdministratorOptions> options, UserManager<AppUser> userManager)
    {
      var user = userManager.FindByEmailAsync(options.Value.EmailAddress).Result;

      if (user is null)
      {
        var identityResult = userManager.CreateAsync(new AppUser
        {
          FirstName = options.Value.FirstName,
          LastName = options.Value.LastName,
          Email = options.Value.EmailAddress,
          UserName = options.Value.UserName,
          PhoneNumber = options.Value.PhoneNumber,
          NormalizedUserName = options.Value.UserName.ToUpper(),
          NormalizedPhoneNumber = options.Value.PhoneNumber.ToUpper()
        },
        options.Value.Password).Result;

        if (!identityResult.Succeeded)
        {
          throw new Exception($"Failed to create administrator user: {string.Join(", ", identityResult.Errors.Select(e => e.Description))}");
        }
      }
    }

    private static void EnsureAdministratorRoleExists(RoleManager<IdentityRole<int>> roleManager)
    {
      var roleExists = roleManager.RoleExistsAsync("Administrator").Result;

      if (!roleExists)
      {
        var role = new IdentityRole<int>
        {
          Name = "Administrator",
          NormalizedName = "ADMINISTRATOR"
        };
        var roleCreationResult = roleManager.CreateAsync(role).Result;
        if (!roleCreationResult.Succeeded)
        {
          throw new Exception($"Failed to create Administrator role: {string.Join(", ", roleCreationResult.Errors.Select(e => e.Description))}");
        }
      }
    }
  }
}
