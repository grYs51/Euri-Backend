using Euri_backend.Data.Models;

namespace Euri_backend.Services.Interfaces;

public interface IUserService
{
    public Task<UserModel> GetUser(string id);
    public Task<IEnumerable<UserModel>> GetAllUsers();
}