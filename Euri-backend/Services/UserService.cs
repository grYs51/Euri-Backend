using Euri_backend.Data.Dto;
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
    
    public async Task<UserModel> GetUser(int id)
    {
        
        return await _repository.GetUser(id);
    }

    public async Task<IEnumerable<UserModel>> GetAllUsers()
    {
        return await _repository.GetAllUsers();
    }

    public Task<UserModel> CreateUser(UserToBeCreatedDto user)
    {
        // todo: Create hashed password
        
        var newUser = new UserModel
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Password = user.Password,
            Email = user.Email,
            Role = user.Role,
            Address = new AddressModel
            {
                Street = user.Address.Street,
                Number = user.Address.Number,
                City = user.Address.City,
                Country = user.Address.Country,
                Zip = user.Address.Zip
            }
        };

        return _repository.CreateUser(newUser);
    }
}