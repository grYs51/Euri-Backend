using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class BasketDto
{
    public BasketDto(BasketModel basket)
    {
        Id = basket.Id;
        DiscountCode = basket.DiscountCode;
        ExpireTime = basket.ExpireTime;
        this.Items = basket.Items.Select(i => new BasketItemDto(i)).ToList();
    }
    
    public int Id { get; set; }
    public IEnumerable<BasketItemDto> Items { get; set; }
    public string DiscountCode { get; set; }
    public DateTime ExpireTime { get; set; }
}