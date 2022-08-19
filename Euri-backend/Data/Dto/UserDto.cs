using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class UserDto
{
    public UserDto(UserModel user)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Email = user.Email;
        Role = user.Role;
        Address = new AddressDto(user.Address);
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public AddressDto Address { get; set; }
}
