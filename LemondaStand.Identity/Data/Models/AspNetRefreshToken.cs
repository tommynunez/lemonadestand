
using System.ComponentModel.DataAnnotations;

namespace LemondaStand.Identity.Data.Models
{
  public class AspNetRefreshToken
  {
    [Key]
    public int Id { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public bool IsExpired => DateTime.UtcNow >= Expires;
    public DateTime Created { get; set; }
    public string CreatedByIp { get; set; }
    public DateTime? Revoked { get; set; }
    public string RevokedByIp { get; set; }
    public string ReplacedByToken { get; set; }
    public bool IsActive => Revoked == null && !IsExpired;

    public AspNetRefreshToken()
    {
      
    }
  }
}
