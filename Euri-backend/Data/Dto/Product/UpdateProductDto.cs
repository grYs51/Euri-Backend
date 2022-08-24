using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class UpdateProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Discount { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }

    public ProductModel ToProductModel()
    {
        return new ProductModel
        {
            Id = Id,
            Name = Name,
            Description = Description,
            Price = Price,
            Discount = Discount,
            Category = Category,
            Stock = Stock
        };
    }
}