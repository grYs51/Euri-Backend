using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class ProductDto
{
    public ProductDto(ProductModel product)
    {
        this.Id = product.Id;
        this.Name = product.Name;
        this.Description = product.Description;
        this.Price = product.Price;
        this.Discount = product.Discount;
        this.Category = product.Category;
        this.Stock = product.Stock;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string Discount { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }
    
}