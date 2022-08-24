using Euri_backend.Data.Models;
using Euri_backend.Utillities;

namespace Euri_backend.Data.Dto;

public class UpdatedUserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Password { get; set; }
    public UpdateAddressDto Address { get; set; }

    public UserModel MapToUserModel(UpdatedUserDto user)
    {
        return new UserModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Role = user.Role,
            Password = user.Password,
            Address = Address.MapToAddressModel(user.Id, user.Address)
        };
    }
}