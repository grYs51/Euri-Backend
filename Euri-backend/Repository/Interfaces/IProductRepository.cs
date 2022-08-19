using Euri_backend.Data.Models;

namespace Euri_backend.Repository.Interfaces;

public interface IProductRepository
{
    Task<ProductModel> GetProduct(int id); 
    Task<IEnumerable<ProductModel>> GetAllProducts();
    Task<ProductModel> CreateProduct(ProductModel product);
    Task<ProductModel> UpdateProduct(ProductModel product);
    Task<ProductModel> DeleteProduct(int id);
}