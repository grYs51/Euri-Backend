using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class UserDto
{
    public UserDto(UserModel user)
    {
        this.Id = user.Id;
        this.FirstName = user.FirstName;
        this.LastName = user.LastName;
        this.Email = user.Email;
        this.Role = user.Role;
        this.Password = user.Password;
        this.Address = new AddressDto(user.Address);
    }
    
    public int Id { get; set; }
    public string FirstName { get;  set; }
    public string LastName { get;  set; }

    public string Password { get; set; }
    public string Email { get;  set; }
    public string Role { get;  set; }
    public AddressDto Address { get;  set; }
}