using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;
using Infrastructure.Model;

namespace ecommerceDemo.Service
{
    public interface ICategoryService
    {
        Task<Category> GetCategory(Expression<Func<Category, bool>> filter);
        Task<List<Category>> GetAllCategories();
        Task<ProcessResult> CreateCategory(CreateCategoryContext context);
    }
}