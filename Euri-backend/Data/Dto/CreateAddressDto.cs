using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class CreateAddressDto
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Number { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
    
    public AddressModel MapToAddressModel()
    {
        return new AddressModel
        {
            Street = Street,
            City = City,
            Number = Number,
            Zip = Zip,
            Country = Country
        };
    }
}