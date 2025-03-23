using Microsoft.AspNetCore.Mvc;

namespace LemonadeStand.IdentityServer
{
  public class AuthenticationController : Controller
  {
    public AuthenticationController()
    {

    }

    [HttpPost]
    public async Task<IActionResult> Login()
    {

    }

    [HttpPost]
    public async Task<IActionResult> GoogleAuthentication()
    {

    }
  }
}