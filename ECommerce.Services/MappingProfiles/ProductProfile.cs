using AutoMapper;
using ECommerce.Domain.Entities.ProductModule;
using ECommerce.Shared.DTos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductBrand, BrandDto>();

            CreateMap<Product, productDTO>()
                .ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(x => x.productBrand.Name))
                .ForMember(dest => dest.productType, opt => opt.MapFrom(x => x.ProductType.Name))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProductPictureUrlResolver>());

            CreateMap<ProductType, TypeDto>();
        }
    }
}
