using System.Runtime.Serialization;
using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class UpdateAddressDto
{
    [IgnoreDataMember]
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Number { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
    
    public AddressModel MapToAddressModel( int id, UpdateAddressDto createAddressDto)
    {
        return new AddressModel
        {
            UserAddressId = id,
            Street = createAddressDto.Street,
            City = createAddressDto.City,
            Number = createAddressDto.Number,
            Zip = createAddressDto.Zip,
            Country = createAddressDto.Country
        };
    }
}