
using LemonadeStand.IdentityServer.Abstractions.Enums;

public interface IAuthenticationProviders
{
  public AuthenticationProvier AuthenticationProvier { get; set; }
  public void Authenticate();
}