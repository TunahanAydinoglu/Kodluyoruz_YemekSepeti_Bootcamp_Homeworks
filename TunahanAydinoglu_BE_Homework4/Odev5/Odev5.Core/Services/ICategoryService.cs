using Odev5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Odev5.Core.Services
{
    public interface ICategoryService : IServiceBase<Category>
    {
        Task<Category> GetProductsByCategoryIdAsync(int categoryId);
    }
}
