using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared
{
    public class ProductQueryParams
    {
        public int? brandId {  get; set; }
        public int? typeId { get; set; }
        public string? search { get; set; }
        public ProductSortingOptions? sort { get; set; }

        private int _pageIndex=1;

        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                _pageIndex=(value<=0)?1:value; 
            }
        }

        private const int DefaultPageSize = 5;
        private const int MaxSize = 10;
        private int _pageSize = DefaultPageSize;

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if(value<=0)
                    _pageSize=DefaultPageSize;
                else if(value>=10)
                    _pageSize=MaxSize;
                else
                {
                    PageSize = value;   
                }
            }
            
        }


    }
}
