using Euri_backend.Data.Models;
using Euri_backend.Repository.Interfaces;
using Euri_backend.Services.Interfaces;

namespace Euri_backend.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<UserModel> GetUser(string id)
    {
        return await _repository.GetUser(id);
    }

    public async Task<IEnumerable<UserModel>> GetAllUsers()
    {
        return await _repository.GetAllUsers();
    }
}