using ECommerce.Domain.Entities.ProductModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Perisistance.Data.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.PictureUrl).HasMaxLength(200);
            builder.Property(x => x.Price).HasPrecision(18,2);

            builder.HasOne(x=>x.productBrand).WithMany().HasForeignKey(x=>x.BrandId);

            builder.HasOne(x => x.ProductType).WithMany().HasForeignKey(x => x.TypeId);

        }
    }
}
