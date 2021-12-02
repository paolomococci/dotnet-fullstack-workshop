using System.ComponentModel.DataAnnotations;

namespace Cruises.Application.Dtos.User
{
  public class AuthenticateRequest
  {
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
  }
}
