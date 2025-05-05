using System.Net;
using System.Security.Claims;
using LemonadeStand.IdentityServer.Enums;
using System.Web.Http;
using LemonadeStand.IdentityServer.Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;

namespace LemonadeStand.IdentityServer.Services
{
  public interface IAuthenticationService
  {
    Task<object> Signup(string email, string username,  string password, string confirmPassword);
    Task Signin(string? username, string? password);
  }

  public class AuthenticationService : IAuthenticationService
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private HttpContext? _httpContext;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    public AuthenticationService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
    {
      _httpContextAccessor = httpContextAccessor;
      _httpContext = _httpContextAccessor?.HttpContext;
      _userManager = userManager;
    }

    public async Task<object> Signup(string email, string username, string password, string confirmPassword)
    {
      ValidateArgs(email, username, password, confirmPassword);

      //Step 1: Check if the user exists based on email address 
      //        If the user exists then check whether or no email address
      //        is confirmed. 
      var user = await _userManager.FindByEmailAsync(email);
      if (user is not null)
      {
        var isEmailconfirmed = await _userManager.IsEmailConfirmedAsync(user);
        if(isEmailconfirmed)
        {
          return new { message = "An email was sent to your account" };
        } else
        {
          //Todo: generate email confirmation token & send email link token
          return new { message = "An email was sent to your account" };
        }
      }

      user = new AppUser
      {
        Email = email,
        NormalizedEmail = email.Normalize().ToUpperInvariant(),
      };

      var wasUsercreated = await _userManager.CreateAsync(user, password);

      if(wasUsercreated.Succeeded)
      {
        var confirmationEmailtoken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //Todo: send email address to confirm emailaddress
        //var confirmationLink =  ;
        var url = new UrlHelper(new ActionContext { HttpContext = _httpContext}).Action(nameof(Signup), );
      } else
      {

      }

      return new { message = "Please check your email address to confirm your account creation" }; 
    }

    private static void ValidateArgs(string email, string username, string password, string confirmPassword)
    {
      if (string.IsNullOrEmpty(email))
      {
        throw new HttpResponseException(new HttpResponseMessage
        {
          StatusCode = HttpStatusCode.BadRequest,
          Content = new StringContent(nameof(email))
        });
      }

      if (string.IsNullOrEmpty(username))
      {
        throw new HttpResponseException(new HttpResponseMessage
        {
          StatusCode = HttpStatusCode.BadRequest,
          Content = new StringContent(nameof(username))
        });
      }

      if (string.IsNullOrEmpty(password))
      {
        throw new HttpResponseException(new HttpResponseMessage
        {
          StatusCode = HttpStatusCode.BadRequest,
          Content = new StringContent(nameof(password))
        });
      }

      if (string.IsNullOrEmpty(confirmPassword))
      {
        throw new HttpResponseException(new HttpResponseMessage
        {
          StatusCode = HttpStatusCode.BadRequest,
          Content = new StringContent(nameof(confirmPassword))
        });
      }

      if (password != confirmPassword)
      {
        throw new HttpResponseException(new HttpResponseMessage
        {
          StatusCode = HttpStatusCode.BadRequest,
          Content = new StringContent("Password does not match confirm password")
        });
      }
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