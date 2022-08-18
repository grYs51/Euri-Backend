using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class CreateAddressDto
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Number { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
    
    public AddressModel MapToAddressModel( CreateAddressDto createAddressDto)
    {
        return new AddressModel
        {
            Street = createAddressDto.Street,
            City = createAddressDto.City,
            Number = createAddressDto.Number,
            Zip = createAddressDto.Zip,
            Country = createAddressDto.Country
        };
    }
}