using Odev5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Odev5.Core.Repositories
{
    public interface ICategoryRepository:IRepositoryBase<Category>
    {
        Task<Category> GetProductsByCategoryIdAsync(int categoryId);
    }
}
