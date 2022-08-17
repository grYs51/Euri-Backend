using Euri_backend.Data;
using Euri_backend.Data.Dto;
using Euri_backend.Data.Models;
using Euri_backend.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Euri_backend.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _ctxt;

    public UserRepository(AppDbContext ctxt)
    {
        _ctxt = ctxt;
    }
    public async Task<UserModel> GetUser(int id)
    {
        return await _ctxt.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<UserModel>> GetAllUsers()
    {
        return await _ctxt.Users.Include(x => x.Address).ToListAsync();
    }

    public async Task<UserModel> CreateUser(UserModel user)
    {
        _ctxt.Add(user);

        await _ctxt.SaveChangesAsync();
        return user;
    }
}