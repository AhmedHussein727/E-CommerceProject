using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.ProductModule;
using ECommerce.Domain.Interfaces;
using ECommerce.Perisistance.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.Perisistance.Data.DataSeed
{
    public class DataSeeding : IDataSeeding
    {
        private readonly StoreDbContext dbContext;

        public DataSeeding(StoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task SeedAsync()
        {
            try
            {
                var HasProducts=await dbContext.products.AnyAsync();
                var HasProductBrands=await dbContext.productBrands.AnyAsync();
                var HasProductTypes=await dbContext.productTypes.AnyAsync();
                if (HasProducts && HasProductBrands && HasProductTypes) return;

                
                if(!HasProductBrands)
                {
                    await SeedDataFromJsonAsync<ProductBrand, int>("brands.json", dbContext.productBrands);
                }
                if(!HasProductTypes)
                {
                    await SeedDataFromJsonAsync<ProductType, int>("types.json", dbContext.productTypes);
                }
               await dbContext.SaveChangesAsync();
                if (!HasProducts)
                {
                    await SeedDataFromJsonAsync<Product, int>("products.json", dbContext.products);
                }
               await dbContext.SaveChangesAsync ();


            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Data Seeding Field {ex}");
            }
        }

        private async Task SeedDataFromJsonAsync<T,TKey>(string fileName,DbSet<T> dbset)where T : BaseEntity<TKey>
        {
        //E:\Course BackEnd ASP.NET\API\E - CommerceSolution\ECommerce.Perisistance\Data\DataSeed\JSONfiles\brands.json
        var filePath = @"..\ECommerce.Perisistance\Data\DataSeed\JSONfiles\"+fileName;
            if (!File.Exists(filePath)) return;
            try
            {
                using var DataStream=File.OpenRead(filePath);
                var data=await JsonSerializer.DeserializeAsync<List<T>>(DataStream,new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                if(data is not null  )
                {
                   await dbset.AddRangeAsync(data);
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Error While Reading Json File {ex}");
                return;
            }
        }
    }
}
