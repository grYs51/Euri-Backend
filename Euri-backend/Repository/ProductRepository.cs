using Euri_backend.Data;
using Euri_backend.Data.Models;
using Euri_backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Euri_backend.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _ctxt;
    
    public ProductRepository(AppDbContext ctxt)
    {
        _ctxt = ctxt;
    }
    
    public async Task<ProductModel> GetProduct(int id)
    {
        return await _ctxt.Products.FindAsync(id);
    }

    public async Task<IEnumerable<ProductModel>> GetAllProducts()
    {
        return await _ctxt.Products.ToListAsync();
    }

    public async Task<ProductModel> CreateProduct(ProductModel product)
    {
        await _ctxt.Products.AddAsync(product);
        await _ctxt.SaveChangesAsync();
        return product;
    }

    public async Task<ProductModel> UpdateProduct(ProductModel product)
    {
        try
        {
            _ctxt.Products.Update(product);
            await _ctxt.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            if (!ProductExists(product.Id))
            {
                return null;
            }
            else
            {
                throw;
            }
        }

        return product;
    }

    public async Task<ProductModel> DeleteProduct(int id)
    {
        var product = await _ctxt.Products.FindAsync(id);
        _ctxt.Products.Remove(product);
        await _ctxt.SaveChangesAsync();
        return product;
    }
    
    private bool ProductExists(int id)
    {
        return _ctxt.Products.Any(e => e.Id == id);
    }
}