using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odev5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odev5.Data.Seeds
{
    class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _categoryIds;
        public ProductSeed(int[] categoryIds)
        {
            _categoryIds = categoryIds;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Trampet", Price = 120.50m, Stock = 20, IsActive = true, CategoryId = _categoryIds[1] },
                new Product { Id = 2, Name = "Klasık Gıtar", Price = 220.50m, Stock = 15, IsActive = false, CategoryId = _categoryIds[0] },
                new Product { Id = 3, Name = "Elektro Gıtar", Price = 137.53m, Stock = 10, IsActive = true, CategoryId = _categoryIds[0] },
                new Product { Id = 4, Name = "Baglama", Price = 99.50m, Stock = 20, IsActive = true, CategoryId = _categoryIds[0] },
                new Product { Id = 5, Name = "Blok Flut", Price = 15.50m, Stock = 20, IsActive = true, CategoryId = _categoryIds[2] }
                );
        }
    }
}
