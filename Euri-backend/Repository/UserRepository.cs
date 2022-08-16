using Euri_backend.Data;
using Euri_backend.Data.Models;
using Euri_backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Euri_backend.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _ctxt;

    public UserRepository(AppDbContext Ctxt)
    {
        _ctxt = Ctxt;
    }
    public async Task<UserModel> GetUser(string id)
    {
        return await _ctxt.Users.Include(x => x.Adress).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<UserModel>> GetAllUsers()
    {
        return await _ctxt.Users.Include(x => x.Adress).ToListAsync();
    }
}