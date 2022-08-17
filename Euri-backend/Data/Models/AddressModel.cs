namespace Euri_backend.Data.Models;

public class AddressModel
{
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Number { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
}