using System.Net;
using System.Security.Claims;
using System.Web.Http;
using LemonadeStand.IdentityServer.Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace LemonadeStand.IdentityServer.Services
{
  public interface IAuthenticationService
  {
    Task Signin(string? username, string? password);
  }

  public class AuthenticationService : IAuthenticationService
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly SignInManager<AppUser> _signInManager; 
    public AuthenticationService(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    public async Task Signin(string? username, string? password)
    {
      if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
      {
          throw new HttpResponseException(HttpStatusCode.Unauthorized);
      }

      var isAuthenticated = await _signInManager.PasswordSignInAsync(username, password, true, true);
      
      

      await AddAuthenticatedUserClaim();
    }
    
    private async Task AddAuthenticatedUserClaim()
    {
      var claims = new List<Claim>()
      {
        new Claim(ClaimTypes.Name, "Thomas Nunez")
      };

      var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

      await _httpContextAccessor.HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
    }
  }
}