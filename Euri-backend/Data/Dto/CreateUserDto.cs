using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class CreateUserDto
{
    public string FirstName { get;  set; }
    public string LastName { get;  set; }
    public string Email { get;  set; }
    public string Role { get;  set; }
    public string Password { get;  set; }
    public CreateAddressDto Address { get;  set; }

    public UserModel MapToUserModel(CreateUserDto user)
    {
        return new UserModel
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Role = user.Role,
            Password = user.Password,
            Address = Address.MapToAddressModel(user.Address)
        };
    }
}