using Euri_backend.Data.Models;

namespace Euri_backend.Repository.Interfaces;

public interface IUserRepository
{
    Task<UserModel> GetUser(string id);
    Task<IEnumerable<UserModel>> GetAllUsers();
}