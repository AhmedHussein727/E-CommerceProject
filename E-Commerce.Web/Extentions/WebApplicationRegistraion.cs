using ECommerce.Domain.Interfaces;
using ECommerce.Perisistance.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace E_Commerce.Web.Extentions
{
    public static class WebApplicationRegistraion
    {
        public static async Task<WebApplication> MigrateDatabaseAsync(this WebApplication app)
        {
           await using var scope = app.Services.CreateAsyncScope();
            var DbContextServices = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
            var PendingMigrations =await DbContextServices.Database.GetPendingMigrationsAsync();
            if (PendingMigrations.Any())
            {
               await DbContextServices.Database.MigrateAsync();
            }
            return app;
        }

        public static async Task<WebApplication> SeedDatabaseAsync(this WebApplication app)
        {
           await using var scope = app.Services.CreateAsyncScope();
            var dataSeedingService = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
           await dataSeedingService.SeedAsync();
            return app;
        }
    }
}
