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

        public async Task CreateCategory(Category category)
            => await _categoryRepository.Create(category);

        public async Task FindAndUpdateCategory(Expression<Func<Category, bool>> filterDefinition, Action<Category> updateDefinition)
            => await _categoryRepository.FindAndUpdate(filterDefinition, updateDefinition);

        public async Task<Category> GetCategory(Expression<Func<Category, bool>> filter)
            => await _categoryRepository.Get(filter);

        public async Task<List<Category>> GetCategories(Expression<Func<Category, bool>> filter = null)
            => await _categoryRepository.GetList(filter);

        public async Task RemoveCategory(Category category)
            => await _categoryRepository.Remove(category);

        public async Task UpdateCategory(Category category)
            => await _categoryRepository.Update(category);
    }
}