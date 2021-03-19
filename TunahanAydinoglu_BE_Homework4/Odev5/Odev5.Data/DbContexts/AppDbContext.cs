using System;
using System.Collections.Generic;
using System.Text;
using Odev5.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Odev5.Data.Seeds;
using Microsoft.Extensions.Configuration;

namespace Odev5.Data.DbContexts
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2, 3 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2, 3 }));

        }
    }
}
