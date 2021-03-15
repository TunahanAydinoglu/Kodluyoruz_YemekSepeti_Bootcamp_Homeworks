using Microsoft.EntityFrameworkCore;
using Odev4.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev4.API.Data.Context
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }


    }
}
