using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class CreateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
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
            Password = Password,
            Address = Address.MapToAddressModel()
        };
    }
}