using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class AddressDto
{
    public AddressDto(AddressModel address)
    {
        this.Street = address.Street;
        this.City = address.City;
        this.Number = address.Number;
        this.Zip = address.Zip;
        this.Country = address.Country;
    }
    public string Street { get; set; }
    public string City { get; set; }
    public string Number { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
    
}