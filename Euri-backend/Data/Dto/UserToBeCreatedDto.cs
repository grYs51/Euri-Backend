using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class UserToBeCreatedDto
{

    public string FirstName { get;  set; }
    public string LastName { get;  set; }
    public string Email { get;  set; }
    public string Role { get;  set; }
    public string Password { get;  set; }
    public AddressToBeCreatedDto Address { get;  set; }
}

public class AddressToBeCreatedDto {
    public string Street { get; set; }
    public string City { get; set; }
    public string Number { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
}