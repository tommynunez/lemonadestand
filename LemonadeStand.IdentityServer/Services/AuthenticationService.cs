using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using LemonadeStand.IdentityServer.Enums;
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
    private HttpContext _httpContext;
    private readonly SignInManager<AppUser> _signInManager;
    public AuthenticationService(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
      _httpContext = _httpContextAccessor.HttpContext;
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
      //add the claims 
      var claims = new List<Claim>()
      {
        new Claim(ClaimTypes.Name, "Thomas Nunez"),
        new Claim(ClaimTypes.Role, value: LemonadeStandRoles.Administrator.ToString())
      };

      //create identity claims with auth type
      var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

      await _httpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
    }
  }
}