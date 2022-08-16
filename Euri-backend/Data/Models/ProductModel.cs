namespace Euri_backend.Data.Models;

public class ProductModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string Discount { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }
}