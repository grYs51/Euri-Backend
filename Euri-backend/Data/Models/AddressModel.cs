using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Euri_backend.Data.Models;

public class AddressModel
{
    [Key]
    public int UserAddressId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Number { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
    
    public UserModel User { get; set; }
}