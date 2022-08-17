using Euri_backend.Data;
using Euri_backend.Data.Models;
using Euri_backend.Repository.Interfaces;
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

    public async Task<UserModel> UpdateUser(UserModel user)
    {
        _ctxt.Entry(user).State = EntityState.Modified;
        _ctxt.Entry(user.Address).State = EntityState.Modified; 
        try
        {
            await _ctxt.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            if (!UserExists(user.Id))
            {
                return null;
            }
            else
            {
                throw;
            }
        }
        return user;
    }

    public async Task<UserModel> DeleteUser(int id)
    {
        var user = await _ctxt.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
        
        if (user == null)
        {
            return null;
        }
        _ctxt.Users.Remove(user);
        await _ctxt.SaveChangesAsync();
        return user;
    }

    private bool UserExists(int id)
    {
        return (_ctxt.Users.Any(x => x.Id == id));
    }
}