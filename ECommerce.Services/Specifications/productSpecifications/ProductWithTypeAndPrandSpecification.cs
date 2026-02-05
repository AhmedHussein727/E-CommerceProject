using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.ProductModule;
using ECommerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Specifications.productSpecifications
{
    internal class ProductWithTypeAndPrandSpecification :BaseSpecifications<Product,int>
    {
        public ProductWithTypeAndPrandSpecification(ProductQueryParams queryParams):base(productSpecificationsHelper.GetCriteria(queryParams))
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.productBrand);
            switch (queryParams.sort)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                case  ProductSortingOptions.NameDesc:
                    AddOrderByDesc(p => p.Name);
                    break;
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDesc(p => p.Price);
                    break;
                default:
                    AddOrderBy(p=>p.Id);
                    break;

            }

            ApplyPagination(queryParams.PageSize, queryParams.PageIndex);
        }

        public ProductWithTypeAndPrandSpecification(int id):base(x=>x.Id==id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.productBrand);

        }
    }
}
