using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odev5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odev5.Data.Seeds
{
    class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _ids;
        public CategorySeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                    new Category { Id = _ids[0], Name = "Telliler", IsActive = true },
                    new Category { Id = _ids[1], Name = "Vurmalilar", IsActive = true },
                    new Category { Id = _ids[2], Name = "Uflemeliler", IsActive = true }
                );
        }
    }
}
