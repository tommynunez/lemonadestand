using AutoMapper;
using LemondaStand.Identity.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
  }
}
