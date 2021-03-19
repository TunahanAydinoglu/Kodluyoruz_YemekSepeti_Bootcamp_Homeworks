using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5.DapperAPI.Models
{
    public class ProductSubcategory
    {
        public int ProductSubcategoryID { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
    }
}
