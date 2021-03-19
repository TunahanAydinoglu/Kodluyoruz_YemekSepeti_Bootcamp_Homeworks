using System;
using System.Collections.Generic;
using System.Text;

namespace Odev5.Service.Dtos
{
    public class ProductDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
