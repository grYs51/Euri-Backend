using Euri_backend.Data;
using Euri_backend.Data.Models;

namespace Euri_backend.Testing.Utilities;

public class Utilities
{
    public static void InitializeDbForTests(AppDbContext db)
    {
        db.Users.AddRange(GetUsers());
        db.SaveChanges();
    }

    public static void ReinitializeDbForTests(AppDbContext db)
    {
        db.Users.RemoveRange(db.Users);
        InitializeDbForTests(db);
    }

    public static List<UserModel> GetUsers()
    {
        return new List<UserModel>
        {
            new UserModel
            {
                FirstName = "test1",
                LastName = "test1",
                Password = "123456",
                Email = "test.test@euri.com",
                Role = "admin",
                Address = new AddressModel
                {
                    Street = "teststreet",
                    City = "testcity",
                    Number = "1",
                    Zip = "2000",
                    Country = "testCountry",
                    User = null
                }
            },
            new UserModel
            {
                FirstName = "test2",
                LastName = "test2",
                Password = "123456",
                Email = "test2.test2@euri.com",
                Role = "user",
                Address = new AddressModel
                {
                    Street = "teststreet",
                    City = "testcity",
                    Number = "1",
                    Zip = "2000",
                    Country = "testCountry",
                    User = null
                }
            }
        };
    }
}