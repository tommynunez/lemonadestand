using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LemonadeStand.IdentityServer.Data;
using LemonadeStand.IdentityServer.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var app = builder.Build();

services.AddDbContext<IdentityServerDbContext>(options =>
        options.UseSqlServer());

services.AddIdentityCore<AppUser<Guid>>()
        .AddEntityFrameworkStores<IdentityServerDbContext>();

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);


app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.Run();
