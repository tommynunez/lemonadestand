using System.Security.Claims;
using System.Threading.Tasks;
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
    public AuthenticationService(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    public async Task Signin()
    {
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