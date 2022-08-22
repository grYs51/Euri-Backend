using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class BasketItemDto
{
    public BasketItemProductDto Product { get; set; }
    public int Quantity { get; set; }
    
    public BasketItemDto(BasketItemModel item )
    {
        this.Product = new BasketItemProductDto(item.Product);
        this.Quantity = item.Quantity;
    }

}