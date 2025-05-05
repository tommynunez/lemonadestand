using AutoMapper;
using LemonadeStand.IdentityServer.Common.Models;
using LemonadeStand.IdentityServer.Data;
using LemonadeStand.IdentityServer.Data.Entities;
using LemonadeStand.IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LemonadeStand.IdentityServer
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class AuthenticationController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly ILogger<AuthenticationController> _logger;
    private readonly UserManager<AppUser> _userManager;
    private readonly IdentityServerDbContext _identityServerDbContext;
    private IAuthenticationService _authenticationService;
    private IConfiguration _configuration;

    public AuthenticationController(IMapper mapper, ILogger<AuthenticationController> logger,
      UserManager<AppUser> userManager, IdentityServerDbContext identityServerDbContext,
      IAuthenticationService authenticationService, IConfiguration configuration)
    {
      _mapper = mapper;
      _logger = logger;
      _userManager = userManager;
      _identityServerDbContext = identityServerDbContext;
      _authenticationService = authenticationService;
      _configuration = configuration;
    }

    [AllowAnonymous]
    [Route("Login")]
    [HttpPost]
    public async Task<ActionResult> Login([FromBody] SignInDTO signInModel)
    {
      if(ModelState.IsValid)
      {
        //get the user and session token
        var user = await _identityServerDbContext
          .Users.Include(x => x.RefreshTokens)
          .SingleOrDefaultAsync(u => u.NormalizedEmail == signInModel.Email);


        if (user is not null)
        {
          //check if user is locked out
          if (await _userManager.IsLockedOutAsync(user))
          {
            //Todo: send an email
            return StatusCode(423, new { errorMessage = "Account is locked out" });
          }

          //authenticathe the user with password
          if(await _userManager.CheckPasswordAsync(user, signInModel.Password))
          {
            //if email address has not been confirmed yet
            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
              var generateToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
              string tokenUrl = Url.Action("EmailConfirmation",
                                           "Authentication",
                                           new { token = generateToken, email = user.Email },
                                           Request.Scheme);

            }
          }
        }
      }
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] SigninRequest signinRequest)
    {
      await _authenticationService.Signin(signinRequest.Username, signinRequest.Password);
      return Ok();
    }
  }
}