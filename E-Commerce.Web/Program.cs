
using E_Commerce.Web.Extentions;
using ECommerce.Domain.Interfaces;
using ECommerce.Perisistance.Data.DataSeed;
using ECommerce.Perisistance.Data.DbContexts;
using ECommerce.Perisistance.Repositories;
using ECommerce.Services;
using ECommerce.Services.MappingProfiles;
using ECommerce.services_Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Threading.Tasks;

namespace E_Commerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            #region Program code
            var builder = WebApplication.CreateBuilder(args);



            #region Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IDataSeeding, DataSeeding>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(ServicesAssemblyReference).Assembly);
            builder.Services.AddScoped<IProductService, ProductService>();
            #endregion

            var app = builder.Build();

            #region Data Seeding
            await app.MigrateDatabaseAsync();
            await app.SeedDatabaseAsync();
            #endregion


            #region Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.MapControllers();
            #endregion

            await app.RunAsync(); 
            #endregion
        }
    }
}
