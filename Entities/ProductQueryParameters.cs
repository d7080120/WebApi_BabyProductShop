using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

    public class ProductQueryParameters
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Name { get; set; }
        public int? CategoryId { get; set; }
        public string SortBy { get; set; } = "name"; // "price" or "name"
        public string SortDirection { get; set; } = "asc"; // "asc" or "desc"
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

}
