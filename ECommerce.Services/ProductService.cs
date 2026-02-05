using AutoMapper;
using ECommerce.Domain.Entities.ProductModule;
using ECommerce.Domain.Interfaces;
using ECommerce.Services.Specifications;
using ECommerce.services_Abstraction;
using ECommerce.Shared;
using ECommerce.Shared.DTos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var brands=await unitOfWork.GetRepository<ProductBrand,int>().GetAllAsync();
            return mapper.Map<IEnumerable<BrandDto>>(brands);
        }

        

        public async Task<PaginatedResult<productDTO>> GetAllProductsAsync(ProductQueryParams queryParams)
        {
            var repo = unitOfWork.GetRepository<Product, int>();
            var spec = new ProductWithTypeAndPrandSpecification(queryParams);
             
            var products=await repo.GetAllAsync(spec);
            var ProuctsWithCountSpecifications = new ProductWithCountSpesifications(queryParams);
            var totalCount=await repo.countAsync(ProuctsWithCountSpecifications);

            var DataToReturn= mapper.Map<IEnumerable<productDTO>>(products);
            var countOfReturnData=DataToReturn.Count();
            return new PaginatedResult<productDTO>
                (
                    queryParams.PageIndex,
                    countOfReturnData,
                    totalCount,
                    DataToReturn
                );
        }



        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var types=await unitOfWork.GetRepository<ProductType,int>().GetAllAsync();
            return mapper.Map<IEnumerable<TypeDto>>(types);
        }

        public async Task<productDTO> GetProductByIDAsync(int id)
        {
            var spec=new ProductWithTypeAndPrandSpecification(id);
            var product = await unitOfWork.GetRepository<Product, int>().GetByIdAsync(spec);
            return mapper.Map<productDTO>(product);

        }
    }
}
