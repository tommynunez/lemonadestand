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

                var tonnectProjects = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IMigratable).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);


                foreach (var tProject in tonnectProjects)
                {
                    if (tProject != null)
                    {
                        using (var scope = app.ApplicationServices.CreateScope())
                        {
                            try
                            {
                                Type pl = tProject;
                                var dbContext = scope.ServiceProvider.GetRequiredService(pl) as DbContext;
                                //dbContext?.Database.Migrate();
                            }
                            catch (Exception ex)
                            {
                                
                            }
                        }
                    }
                }
            }
        }
	}
}

