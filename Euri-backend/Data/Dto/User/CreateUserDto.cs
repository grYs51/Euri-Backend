using System.ComponentModel.DataAnnotations;
using Euri_backend.Data.Models;
using Euri_backend.Utillities;

namespace Euri_backend.Data.Dto;

public class CreateUserDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string Role { get; set; }
    [Required]
    public string Password { get; set; }
    public CreateAddressDto Address { get; set; }

    public UserModel MapToUserModel()
    {
        return new UserModel
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Role = Role,
            Password = BCrypt.Net.BCrypt.HashPassword(Password),
            Address = Address.MapToAddressModel()
        };
    }
}