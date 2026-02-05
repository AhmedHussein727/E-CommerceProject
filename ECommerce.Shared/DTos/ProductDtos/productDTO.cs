using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTos.ProductDtos
{
    public class productDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; }= default!;
        public string PictureUrl { get; set; }=default!;
        public decimal price { get; set; }
        public string productType { get; set; } = default!;
        public string ProductBrand { get; set; }= default!;
    }
}
