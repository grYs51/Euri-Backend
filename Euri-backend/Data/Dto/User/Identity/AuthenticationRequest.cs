using System.ComponentModel.DataAnnotations;

namespace Euri_backend.Data.Dto.Identity;

public class AuthenticationRequest
{
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}