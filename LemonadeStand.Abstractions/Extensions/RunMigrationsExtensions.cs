using LemonadeStand.Abstractions.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LemonadeStand.Abstractions.Extensions
{
  public static class RunMigrationsExtensions
  {
    public static void AddRunMigrationsExtensions(this IServiceCollection service, IApplicationBuilder app, IConfiguration configuration)
    {
      if (Convert.ToBoolean(configuration["RunMigrations"]))
      {
        IEnumerable<Type> projects = RetrieveIMigratableMarkedProjectsInAssembly();
        CheckListofProjects(app, projects);
      }
    }

    private static IEnumerable<Type> RetrieveIMigratableMarkedProjectsInAssembly()
    {
      return AppDomain.CurrentDomain.GetAssemblies()
      .SelectMany(x => x.GetTypes())
      .Where(x => typeof(IMigratable).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
    }

    private static void CheckListofProjects(IApplicationBuilder app, IEnumerable<Type> projects)
    {
      foreach (var tProject in projects)
      {
        if (tProject != null)
        {
          ExecuteMigration(app, tProject);
        }
      }
    }

    private static void ExecuteMigration(IApplicationBuilder app, Type tProject)
    {
      try
      {
        var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService(tProject) as DbContext;
        dbContext?.Database.Migrate();
      }
      catch (Exception ex)
      {
        //var logger = app.ApplicationServices.GetService<ILogger>();
        //logger?.LogError("RunMigrationsExtensions::ExecuteMigtration Could not complete migration {message}", ex.Message);
      }
    }
  }
}

