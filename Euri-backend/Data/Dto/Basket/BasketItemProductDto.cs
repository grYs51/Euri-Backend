using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class BasketItemProductDto
{
    public BasketItemProductDto(ProductModel product)
    {
        this.Name = product.Name;
        this.Price = product.Price;
        this.Discount = product.Discount;
    }
    
    public string Name { get; set; }
    public double Price { get; set; }
    public double Discount { get; set; }
    
}