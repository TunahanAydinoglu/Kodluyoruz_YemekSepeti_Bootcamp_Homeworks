using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week2.WebApi.Data.Entity
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Hour { get; set; }
    }
}
