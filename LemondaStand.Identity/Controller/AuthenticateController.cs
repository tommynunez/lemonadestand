using AutoMapper;
using LemondaStand.Identity.Data;
using LemondaStand.Identity.Data.Models;
using LemondaStand.Identity.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LemondaStand.Identity.Controller
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class AuthenticateController : ControllerBase
  {
    private readonly ILogger<AuthenticateController> _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IdentityDatabaseContext _identityDatabaseContext;

    public AuthenticateController(ILogger<AuthenticateController> logger,
      IMapper mapper,
      UserManager<AppUser> userManager,
      IConfiguration configuration,
      IdentityDatabaseContext identityDatabaseContext)
    {
      _logger = logger;
      _configuration = configuration;
      _userManager = userManager;
      _mapper = mapper;
      _identityDatabaseContext = identityDatabaseContext;
    }

    [AllowAnonymous]
    [Route("Login")]
    [HttpPost]
    public async Task<ActionResult> Login([FromBody] SigninDto signinDto)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var user = await _identityDatabaseContext
        .Users
        .Include(x => x.IdentityTokens)
        .SingleOrDefaultAsync(x => x.NormalizedEmail == signinDto.Email.ToUpperInvariant());

      if (user != null)
      {
        if (await _userManager.IsLockedOutAsync(user))
        {
          return StatusCode(423, "User account is locked out. Please try again later.");
        }

        if (await _userManager.CheckPasswordAsync(user, signinDto.Password))
        {
          if (!await _userManager.IsEmailConfirmedAsync(user))
          {
            var generatedToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = generatedToken }, Request.Scheme);

            //todo: send confirmation link via email
            return BadRequest(new { errorMessage = "Email not confirmed. Please check your email for confirmation link." });
          }

          await _userManager.ResetAccessFailedCountAsync(user);

          //let's clean up any existing active tokens
          var activeToken = user.IdentityTokens.Where(rt => rt.IsActive);
          if (activeToken.Any())
          {
            foreach (var token in activeToken)
            {
              token.Revoked = DateTime.UtcNow;
              token.RevokedByIp = GetIpAddress();
            }
          }

          var jwtToken = GenerateJwtToken(user, out DateTime now);

          SetTokenCookie(jwtToken);

          user.IdentityTokens.Add(new IdentityToken
          {
            Token = jwtToken,
            Expires = now.AddDays(1), // Set expiration as needed
            Created = now,
            CreatedByIp = GetIpAddress()
          });
          _identityDatabaseContext.Update(user);
          _identityDatabaseContext.SaveChanges();
          return Ok();
        }
        else
        {
          await _userManager.AccessFailedAsync(user);
          var accessFailedCount = await _userManager.GetAccessFailedCountAsync(user);
          // Replace the following block:
          if (accessFailedCount == 3)
          {
            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddMinutes(5));
            return StatusCode(423, "User account is locked out. Please try again later.");
          }
          if (accessFailedCount == 5)
          {
            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddMinutes(15));
            return StatusCode(423, "User account is locked out. Please try again later.");
          }
          return Unauthorized();
        }
      }

      return Ok();
    }

    [Route("logout")]
    [HttpPost]
    [Authorize]
    public async Task<ActionResult> Logout()
    {
      Request.Cookies.TryGetValue("session", out string requestToken);
      if (requestToken is not null)
      {
        return Unauthorized();
      }

      var user = await _identityDatabaseContext
        .Users
        .Include(x => x.IdentityTokens)
        .SingleOrDefaultAsync(x => x.IdentityTokens.Any(t => t.Token == requestToken));

      var token = user.IdentityTokens.Single(x => x.Token == requestToken);

      if (!token.IsActive)
      {
        return Unauthorized();
      }

      token.Revoked = DateTime.UtcNow;
      token.RevokedByIp = GetIpAddress();
      _identityDatabaseContext.Update(user);
      _identityDatabaseContext.SaveChanges();
      return Ok();
    }

    /// <summary>
    /// Get the IP address of the client making the request.
    /// </summary>
    /// <returns></returns>
    [ApiExplorerSettings(IgnoreApi = true)]
    private string GetIpAddress()
    {
      if (Request.Headers.ContainsKey("X-Forwaded-For"))
      {
        return Request.Headers["X-Forwarded-For"];
      }

      return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }

    /// <summary>
    /// Generates a JWT token for the authenticated user and sets it in a cookie.
    /// </summary>
    /// <param name="token"></param>
    [ApiExplorerSettings(IgnoreApi = true)]
    private void SetTokenCookie(string token)
    {
      var cookieOptions = new CookieOptions
      {
        HttpOnly = true,
        Secure = false, // Set to true if using HTTPS
        SameSite = SameSiteMode.None, // Adjust as needed
        Expires = DateTime.UtcNow.AddDays(1) // Set expiration as needed
      };
      Response.Cookies.Append("session", token, cookieOptions);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public string GenerateJwtToken(AppUser apperUser, out DateTime now)
    {
      now = DateTime.UtcNow;
      var tokenHandler = new JwtSecurityTokenHandler();
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
        {
          new Claim(JwtRegisteredClaimNames.Email, apperUser.Email ?? String.Empty),
          new Claim(JwtRegisteredClaimNames.Sub, apperUser.Id.ToString() ?? String.Empty),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
          new Claim("id", apperUser.Id.ToString())
        }),
        Issuer = _configuration["Jwt:Issuer"],
        Audience = _configuration["Jwt:Audience"],
        NotBefore = now,
        IssuedAt = now,
        Expires = now.AddSeconds(900), // Set token expiration time as needed
        SigningCredentials = new SigningCredentials(
          new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? String.Empty)),
          SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
  }
}