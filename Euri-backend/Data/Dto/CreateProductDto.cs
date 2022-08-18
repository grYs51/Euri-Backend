using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class CreateProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string Discount { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }

    public ProductModel ToProductModel()
    {
        return new ProductModel
        {
            Name = Name,
            Description = Description,
            Price = Price,
            Discount = Discount,
            Category = Category,
            Stock = Stock
        };
    }
}