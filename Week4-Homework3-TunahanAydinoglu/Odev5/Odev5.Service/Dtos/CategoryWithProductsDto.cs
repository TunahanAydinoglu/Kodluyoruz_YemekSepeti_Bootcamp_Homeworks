using System;
using System.Collections.Generic;
using System.Text;

namespace Odev5.Service.Dtos
{
    public class CategoryWithProductsDto
    {
        public IEnumerable<ProductDto> Products { get; set; }

    }
}
