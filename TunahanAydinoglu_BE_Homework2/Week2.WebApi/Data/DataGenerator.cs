using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week2.WebApi.Data.Context;
using Week2.WebApi.Data.Entity;

namespace Week2.WebApi.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(
                serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
          
                if (context.Lessons.Any())
                {
                    return;   
                }

                context.Lessons.AddRange(
                    new Lesson
                    {
                        Id = 1,
                        Name = ".Net Core ile backend giris",
                        Hour = 2.2,
                     
                    },
                     new Lesson
                     {
                         Id = 2,
                         Name = "Interface and Abstract",
                         Hour = 3.0,

                     },
                      new Lesson
                      {
                          Id = 3,
                          Name = "React ile Frontend",
                          Hour = 4.3,
                      }
                     );

                context.SaveChanges();
            }
        }
    }
}
