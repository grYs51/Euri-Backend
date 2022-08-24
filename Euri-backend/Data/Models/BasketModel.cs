namespace Euri_backend.Data.Models;

public class BasketModel
{
    public int Id { get; set; }
    public List<BasketItemModel>  Items { get; set; }
    public string DiscountCode { get; set; }
    public DateTime ExpireTime { get; set; }
}