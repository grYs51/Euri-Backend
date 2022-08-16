namespace Euri_backend.Data.Models;

public class BasketModel
{
    public string Id { get; set; }
    public BasketItemModel Items { get; set; }
    public string DiscountCode { get; set; }
    public DateTime ExpireTime { get; set; }
}