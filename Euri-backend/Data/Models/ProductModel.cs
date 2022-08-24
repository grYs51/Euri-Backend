namespace Euri_backend.Data.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public double Discount { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }
}