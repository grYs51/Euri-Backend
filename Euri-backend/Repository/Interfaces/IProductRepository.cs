using Euri_backend.Data.Models;
using Euri_backend.Utillities;

namespace Euri_backend.Repository.Interfaces;

public interface IProductRepository
{
    Task<ProductModel> GetProduct(int id); 
    Task<PagedList<ProductModel>> GetAllProducts(ProductParameters parameters);
    Task<ProductModel> CreateProduct(ProductModel product);
    Task<ProductModel> UpdateProduct(ProductModel product);
    Task<ProductModel> DeleteProduct(int id);
}