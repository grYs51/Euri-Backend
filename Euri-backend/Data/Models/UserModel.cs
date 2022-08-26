using System.ComponentModel.DataAnnotations;
using Euri_backend.Utillities;
using Newtonsoft.Json;

namespace Euri_backend.Data.Models;

public class UserModel
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    public string Role { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
    public AddressModel Address { get; set; }
    
    public string RefreshToken { get; set; }
    public DateTime ExpireTime { get; set; }
}