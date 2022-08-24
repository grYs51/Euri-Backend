using Euri_backend.Data.Models;

namespace Euri_backend.Repository.Interfaces;

public interface IUserRepository
{
    Task<UserModel> GetUser(int id);
    Task<IEnumerable<UserModel>> GetAllUsers();
    Task<UserModel> CreateUser(UserModel user);
    Task<UserModel> UpdateUser(UserModel user);
    Task<UserModel> DeleteUser(int id);
    Task<UserModel> Login(string modelEmail, string modelPassword);
}