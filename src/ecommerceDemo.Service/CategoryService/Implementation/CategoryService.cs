using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;
using ecommerceDemo.Data.Repository;

namespace ecommerceDemo.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> GetCategory(Expression<Func<Category, bool>> filter)
            => await _categoryRepository.Get(filter);

        public async Task<List<Category>> GetCategories(Expression<Func<Category, bool>> filter = null)
            => await _categoryRepository.GetList(filter);
    }
}