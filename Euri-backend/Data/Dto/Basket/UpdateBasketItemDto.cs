using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class UpdateBasketItemDto
{
    public int Id { get; set; }
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