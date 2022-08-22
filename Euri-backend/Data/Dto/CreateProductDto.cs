using System.ComponentModel.DataAnnotations;
using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class CreateProductDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Price { get; set; }
    public string Discount { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
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