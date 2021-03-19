using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Odev5.API.Dtos
{
    public class ProductDto
    {
        public int id { get; set; }
        [Required(ErrorMessage = "{0} alani gerekli bir alandir")]
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
