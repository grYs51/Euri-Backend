using Euri_backend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Euri_backend.Data;

public class AppDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public AppDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<BasketModel> Baskets { get; set; }
    
    public DbSet<BasketItemModel> BasketItems { get; set; }

    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server with connection string from app settings
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>()
            .HasOne(x => x.Address)
            .WithOne(s => s.User)
            .HasForeignKey<AddressModel>(ad => ad.UserAddressId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BasketModel>()
            .HasMany(b => b.Items)
            .WithOne(bi => bi.Basket)
            .HasForeignKey(bi => bi.BasketId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BasketItemModel>()
            .HasOne(i => i.Product);
    }
}