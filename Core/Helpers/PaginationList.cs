using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class PaginationList<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int ProductsCount { get; set; }
        public int RemainProducts => ProductsCount < PageSize * PageNumber ? 0 : (ProductsCount - PageSize * PageNumber);
        public IReadOnlyList<T> Data { get; set; }
    }
}
