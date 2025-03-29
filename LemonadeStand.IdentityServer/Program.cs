using Microsoft.EntityFrameworkCore;
using LemonadeStand.IdentityServer.Data;
using LemonadeStand.IdentityServer.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var app = builder.Build();
builder.Configuration
  .AddJsonFile("appsettings.json")
  .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

//configure database
services.AddDbContext<IdentityServerDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDatabase")));

//configure identity
services.AddIdentityCore<AppUser<Guid>>()
        .AddEntityFrameworkStores<IdentityServerDbContext>();

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);

app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.Run();
