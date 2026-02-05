using ECommerce.Domain.Entities.ProductModule;
using ECommerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Specifications.productSpecifications
{
    internal class ProductWithCountSpesifications:BaseSpecifications<Product,int>
    {
        public ProductWithCountSpesifications(ProductQueryParams queryParams):base(productSpecificationsHelper.GetCriteria(queryParams))
        {
            
        }
    }
}
