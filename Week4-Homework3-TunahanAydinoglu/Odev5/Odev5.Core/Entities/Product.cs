using System;
using System.Collections.Generic;
using System.Text;

namespace Odev5.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }

        public virtual Category Category { get; set; }
    }
}
