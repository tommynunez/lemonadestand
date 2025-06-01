
namespace LemondaStand.Identity.Data.Models
{
  public class AppUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NormalizedPhoneNumber { get; set; }

    public virtual ICollection<AspNetRefreshToken> RefreshTokens {get; set; }

    public AppUser()
    {
      RefreshTokens = new List<AspNetRefreshToken>();
    }
  }
}
