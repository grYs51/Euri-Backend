using Euri_backend.Data.Models;

namespace Euri_backend.Repository.Interfaces;

public interface IBasketRepository
{
    Task<BasketModel> GetBasket(int userId);
    Task<IEnumerable<BasketModel>> GetAllBaskets();
    Task<BasketModel> CreateBasket(BasketModel basket);
    Task<BasketModel> UpdateBasket(BasketModel basket);
    Task<BasketModel> DeleteBasket(int id);
    
}