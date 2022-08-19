using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class AddressDto
{
    public AddressDto(AddressModel address)
    {
        Street = address.Street;
        City = address.City;
        Number = address.Number;
        Zip = address.Zip;
        Country = address.Country;
    }

    public string Street { get; set; }
    public string City { get; set; }
    public string Number { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
}