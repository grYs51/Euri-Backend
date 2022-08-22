namespace Euri_backend.Data.Models;

public class BasketModel
{
    public int Id { get; set; }
    public ICollection<BasketItemModel>  Items { get; set; }
    public string DiscountCode { get; set; }
    public DateTime ExpireTime { get; set; }
}