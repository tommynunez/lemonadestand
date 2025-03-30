using Microsoft.EntityFrameworkCore;
using LemonadeStand.IdentityServer.Data;
using LemonadeStand.IdentityServer.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using LemonadeStand.Abstractions.Extensions;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.Configuration
  .AddJsonFile("appsettings.json")
  .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
  .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.Local.json", optional: true);

#region configure services
//configure database
services.AddDbContext<IdentityServerDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("LemoandeStandDatabase")));

//configure identity
services.AddIdentityCore<AppUser<Guid>>()
        .AddEntityFrameworkStores<IdentityServerDbContext>();

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
        {
          options.Cookie.Name = "lemonadestand";
          options.Cookie.MaxAge = TimeSpan.FromMinutes(12);
          options.SlidingExpiration = true;
          options.Cookie.SameSite = SameSiteMode.None;
          options.Cookie.HttpOnly = true;
          options.Cookie.Domain = "http://localhost:5056";
        });

services.AddAuthorization(options =>
  options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()
);
#endregion

//build web application
var app = builder.Build();

#region migrations
services.AddRunMigrationsExtensions(app, builder.Configuration);
#endregion

app.UseAuthentication();
app.UseAuthorization();
app.Run();
