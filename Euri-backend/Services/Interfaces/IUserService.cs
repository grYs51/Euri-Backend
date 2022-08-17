using Euri_backend.Data.Dto;
using Euri_backend.Data.Models;

namespace Euri_backend.Services.Interfaces;

public interface IUserService
{
    public Task<UserModel> GetUser(int id);
    public Task<IEnumerable<UserModel>> GetAllUsers();
    public  Task<UserModel> CreateUser(UserToBeCreatedDto user);
}