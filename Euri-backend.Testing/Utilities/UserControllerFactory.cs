using Euri_backend.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Euri_backend.Testing.Utilities;

public class UserControllerFactory<TEntrypoint>
    : WebApplicationFactory<Program> where TEntrypoint : Program

{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<AppDbContext>));
            if (descriptor != null)
                services.Remove(descriptor);
            services.AddDbContext<AppDbContext>(options => { options.UseInMemoryDatabase("InMemoryUserTest"); });
            var sp = services.BuildServiceProvider();
            using (var scope = sp.CreateScope())
            using (var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>())
            {
                appContext.Database.EnsureDeleted();
                appContext.Database.EnsureCreated();
                if (appContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                {
                    appContext.Database.Migrate();

                    Utilities.InitializeDbForUserTests(appContext);
                    Utilities.InitializeDbForProductTests(appContext);
                }
            }
        });
    }
}