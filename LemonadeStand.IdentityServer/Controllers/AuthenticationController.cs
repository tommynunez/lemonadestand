using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LemonadeStand.IdentityServer
{
  [Route("authentication")]
  [ApiController]
  public class AuthenticationController
  {
    public AuthenticationController()
    {

    }

    [HttpPost]
    public Task<IActionResult> Login()
    {
      return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> GoogleAuthentication()
    {

    }
  }
}