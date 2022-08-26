using Euri_backend.Data;
using Euri_backend.Data.Models;

namespace Euri_backend.Testing.Utilities;

public class Utilities
{
    public static void InitializeDbForUserTests(AppDbContext db)
    {
        db.Users.AddRange(GetUsers());
        db.SaveChanges();
    }

    public static void InitializeDbForProductTests(AppDbContext db)
    {
        db.Products.AddRange(GetProducts());
        db.SaveChanges();
    }
    
    public static void InitializeDbForBasketTests(AppDbContext db)
    {
        db.Baskets.AddRange(GetBaskets());
        db.SaveChanges();
    }
    
    public static List<UserModel> GetUsers()
    {
        return new List<UserModel>
        {
            new()
            {
                FirstName = "test1",
                LastName = "test1",
                Password = BCrypt.Net.BCrypt.HashPassword("123456"),
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
            new()
            {
                FirstName = "test2",
                LastName = "test2",
                Password = BCrypt.Net.BCrypt.HashPassword("123456"),
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

    public static List<ProductModel> GetProducts()
    {
        return new List<ProductModel>
        {
            new()
            {
                Name = "product1",
                Description = "abc",
                Price = 1,
                Category = "1",
                Discount = 5,
                Stock = 10,
            },
            new()
            {
                Name = "product2",
                Description = "abc",
                Price = 1,
                Category = "1",
                Discount = 5,
                Stock = 10,
            },
            new()
            {
                Name = "product3",
                Description = "abc",
                Price = 1,
                Category = "1",
                Discount = 5,
                Stock = 10,
            },
            new()
            {
                Name = "product4",
                Description = "abc",
                Price = 1,
                Category = "2",
                Discount = 5,
                Stock = 10,
            },
            new()
            {
                Name = "product5",
                Description = "2",
                Price = 1,
                Category = "2",
                Discount = 5,
                Stock = 10,
            },
            new()
            {
                Name = "product6",
                Description = "abc",
                Price = 1,
                Category = "2",
                Discount = 5,
                Stock = 10,
            },
            new()
            {
                Name = "product7",
                Description = "abc",
                Price = 1,
                Category = "3",
                Discount = 6,
                Stock = 10,
            },
            new()
            {
                Name = "product8",
                Description = "abc",
                Price = 1,
                Category = "3",
                Discount = 5,
                Stock = 10,
            },
            new()
            {
                Name = "product9",
                Description = "3",
                Price = 1,
                Category = "3",
                Discount = 5,
                Stock = 10,
            },
            new()
            {
                Name = "product10",
                Description = "abc",
                Price = 1,
                Category = "3",
                Discount = 5,
                Stock = 10,
            },
            new()
            {
                Name = "product11",
                Description = "abc",
                Price = 1,
                Category = "3",
                Discount = 5,
                Stock = 10,
            },
        };
    }

    public static List<BasketModel> GetBaskets()
    {
        return new List<BasketModel>
        {
            new()
            {
                Items = new List<BasketItemModel>
                {
                    new()
                    {
                        ProductId = 1,
                        BasketId = 1,
                        Quantity = 10
                    },
                    new(){
                        ProductId = 2,
                        BasketId = 1,
                        Quantity = 10
                    },
                },
                
                DiscountCode = "discount",
                ExpireTime = default
            },
            new()
            {
                Items = new List<BasketItemModel>
                {
                    new()
                    {
                        Id = 0,
                        ProductId = 3,
                        BasketId = 2,
                        Quantity = 20
                    }
                },
                DiscountCode = null,
                ExpireTime = default
            }
        };
    }
}