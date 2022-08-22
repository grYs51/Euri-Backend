using Euri_backend.Data;
using Euri_backend.Data.Models;
using Euri_backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Euri_backend.Repository;

public class BasketRepository: IBasketRepository
{
    private readonly AppDbContext _ctxt;
    
    public BasketRepository(AppDbContext ctxt)
    {
        _ctxt = ctxt;
    }
    
    public async Task<BasketModel> GetBasket(int userId)
    {
        return await _ctxt.Baskets
            .Include(x => x.Items)
            .ThenInclude(items => items.Product)
            .FirstOrDefaultAsync(x => x.Id == userId);
    }

    public async Task<IEnumerable<BasketModel>> GetAllBaskets()
    {
        return await _ctxt.Baskets
            .Include(x => x.Items)
            .ThenInclude(items => items.Product)
            .ToListAsync();
    }

    public async Task<BasketModel> CreateBasket(BasketModel basket)
    {
         _ctxt.Baskets.Add(basket);
        await _ctxt.SaveChangesAsync();

        var basketEntity = await GetBasket(basket.Id);
        return basketEntity;
        

    }

    public async Task<BasketModel> UpdateBasket(BasketModel basket)
    {
        try
        {
            var basketEntity = await GetBasket(basket.Id);
            basketEntity.Items.Clear();
            
            basketEntity.Items = basket.Items;
            _ctxt.Update(basketEntity);

            await _ctxt.SaveChangesAsync();
            return basketEntity;
        }
        catch (DbUpdateException)
        {
            if(!BasketExists(basket.Id))
            {
                return null;
            }
            else
            {
                throw;
            }
        }

        return basket;
    }

    public async Task<BasketModel> DeleteBasket(int id)
    {
        var basket = await _ctxt.Baskets.FindAsync(id);
        
        if (basket == null)
        {
            return null;
        }
        
        _ctxt.Baskets.Remove(basket);
        await _ctxt.SaveChangesAsync();
        return basket;
    }
    
    private bool BasketExists(int id)
    {
        return (_ctxt.Baskets.Any(x => x.Id == id));
    }
}