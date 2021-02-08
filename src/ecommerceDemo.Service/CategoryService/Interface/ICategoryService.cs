using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Service
{
    public interface ICategoryService
    {
        Task<Category> GetCategory(Expression<Func<Category, bool>> filter);
        Task<List<Category>> GetCategories(Expression<Func<Category, bool>> filter = null);
        Task CreateCategory(Category category);
        Task UpdateCategory(Category category);
        Task FindAndUpdateCategory(Expression<Func<Category, bool>> filterDefinition, Action<Category> updateDefinition);
        Task RemoveCategory(Category category);
    }
}