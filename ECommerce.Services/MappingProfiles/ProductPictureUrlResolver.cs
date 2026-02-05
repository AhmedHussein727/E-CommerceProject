using AutoMapper;
using ECommerce.Domain.Entities.ProductModule;
using ECommerce.Shared.DTos.ProductDtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.MappingProfiles
{
     public class ProductPictureUrlResolver : IValueResolver<Product, productDTO, string>
    {
        private readonly IConfiguration configuration;

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(Product source, productDTO destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl))
            {
                return string.Empty;
            }
            if (source.PictureUrl.StartsWith("http"))
                return source.PictureUrl;
            var BaseUrl = configuration.GetSection("URLs")["BaseUrl"];
            if(string.IsNullOrEmpty(BaseUrl)) return string.Empty;

            var PicUrl=$"{BaseUrl}{source.PictureUrl}";
            return PicUrl;
        }
    }
}
