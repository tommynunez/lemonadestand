var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);


app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.Run();
