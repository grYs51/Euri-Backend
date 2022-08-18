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
                Id = 1,
                FirstName = "test",
                LastName = "test",
                Password = "123456",
                Email = "test.test@euri.com",
                Role = "admin",
                Address = new AddressModel
                {
                    UserAddressId = 1,
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
                Id = 2,
                FirstName = "test2",
                LastName = "test2",
                Password = "123456",
                Email = "test2.test2@euri.com",
                Role = "user",
                Address = new AddressModel
                {
                    UserAddressId = 2,
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