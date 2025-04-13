using LemonadeStand.IdentityServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace LemonadeStand.IdentityServer
{
  [Route("authentication")]
  [ApiController]
  public class AuthenticationController : ControllerBase
  {
    private IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationService)
    {
      _authenticationService = authenticationService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] SigninRequest signinRequest)
    {
      await _authenticationService.Signin(signinRequest.Username, signinRequest.Password);
      return Ok();
    }
  }
}