using ECommerce.Shared;
using ECommerce.Shared.DTos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.services_Abstraction
{
    public interface IProductService
    {
        Task<PaginatedResult<productDTO>> GetAllProductsAsync(ProductQueryParams queryParams);

        Task<productDTO> GetProductByIDAsync(int id);

        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();
    }
}
