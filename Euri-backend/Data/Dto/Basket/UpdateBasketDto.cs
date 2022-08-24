using Euri_backend.Data.Models;

namespace Euri_backend.Data.Dto;

public class UpdateBasketDto
{
    public int Id { get; set; }
    public IEnumerable<CreateBasketItemDto>  Items { get; set; }
    public string DiscountCode { get; set; }
    public DateTime ExpireTime { get; set; }
    
    public BasketModel ToBasketModel()
    {
        return new BasketModel
        {
            Id = Id,
            Items = Items.Select(x => x.ToBasketItemModel()).ToList(),
            DiscountCode = DiscountCode,
            ExpireTime = ExpireTime
        };
    }
}