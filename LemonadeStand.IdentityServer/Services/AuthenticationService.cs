using System.Security.Claims;
using System.Threading.Tasks;
using LemonadeStand.IdentityServer.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace LemonadeStand.IdentityServer.Services
{
  public interface IAuthenticationService
  {
    Task Signin();
  }

  public class AuthenticationService : IAuthenticationService
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private HttpContext _httpContext;
    public AuthenticationService(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
      _httpContext = _httpContextAccessor.HttpContext;
    }

    public async Task Signin()
    {
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