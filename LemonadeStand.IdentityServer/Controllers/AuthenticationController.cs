using Microsoft.AspNetCore.Mvc;

namespace LemonadeStand.IdentityServer
{
  [Route("authentication")]
  [ApiController]
  public class AuthenticationController : ControllerBase
  {
    public AuthenticationController()
    {

    }

    [HttpPost]
    public async Task<IActionResult> Login()
    {
      return Ok();
    }
  }
}