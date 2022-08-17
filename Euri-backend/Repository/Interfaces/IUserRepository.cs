using Euri_backend.Data.Dto;
using Euri_backend.Data.Models;

namespace Euri_backend.Repository.Interfaces;

public interface IUserRepository
{
    Task<UserModel> GetUser(int id);
    Task<IEnumerable<UserModel>> GetAllUsers();
    
    Task<UserModel> CreateUser(UserModel user);
}