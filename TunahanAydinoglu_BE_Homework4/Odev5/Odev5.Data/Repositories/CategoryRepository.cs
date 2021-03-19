using Microsoft.EntityFrameworkCore;
using Odev5.Core.Entities;
using Odev5.Core.Repositories;
using Odev5.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Odev5.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _context.Categories.Include(c => c.Products).SingleOrDefaultAsync(c => c.Id == categoryId);
        }

    }
}
