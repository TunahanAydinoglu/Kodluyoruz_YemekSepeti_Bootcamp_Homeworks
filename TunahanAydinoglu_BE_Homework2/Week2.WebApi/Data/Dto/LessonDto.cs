using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Week2.WebApi.Validation;

namespace Week2.WebApi.Data.Dto
{
    public class LessonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(15, 155, ErrorMessage = "Ders süresi 15-155 dakika aralığında olmalıdır...")]
        public double Minute { get; set; }
    }
}
