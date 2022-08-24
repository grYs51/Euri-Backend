using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class CreateBasketItemDto
{
    public int Id { get; set; }
    // public BasketItemProductModel Product { get; set; }
    public int Quantity { get; set; }
    
    public BasketItemModel ToBasketItemModel()
    {
        return new BasketItemModel
        {
            ProductId = Id,
            Quantity = Quantity
        };
    }
}