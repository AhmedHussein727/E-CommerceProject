using ECommerce.Domain.Entities.ProductModule;
using ECommerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Specifications.productSpecifications
{
    public static class productSpecificationsHelper
    {
        public static Expression<Func<Product,bool>>GetCriteria(ProductQueryParams queryParams)
        {
            return p =>
        (!queryParams.brandId.HasValue || p.BrandId == queryParams.brandId.Value) && (!queryParams.typeId.HasValue || p.TypeId == queryParams.typeId.Value)
        && (string.IsNullOrEmpty(queryParams.search) || p.Name.ToLower().Contains(queryParams.search.ToLower()));
        }
    }
}
