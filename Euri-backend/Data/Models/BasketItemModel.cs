namespace Euri_backend.Data.Models;

public class BasketItemModel
{
    public int Id { get; set; }
    public IEnumerable<BasketItemProductModel> Product { get; set; }
    public int Quantity { get; set; }
}