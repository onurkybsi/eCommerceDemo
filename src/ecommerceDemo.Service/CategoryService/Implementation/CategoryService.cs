using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;
using ecommerceDemo.Data.Repository;
using ecommerceDemo.Service.Common;
using Infrastructure.Model;

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

        public async Task<List<Category>> GetAllCategories()
            => await _categoryRepository.GetList();

        public async Task<ProcessResult> CreateCategory(CreateCategoryContext context)
        {
            ProcessResult createCategoryProcessResult = new ProcessResult();

            if (!(await CheckCreateCategoryProcessIsValid(context.Name, createCategoryProcessResult)))
                return createCategoryProcessResult;

            Category categoryToCreate = new Category
            {
                Name = context.Name,
            };

            await _categoryRepository.Create(categoryToCreate);

            createCategoryProcessResult.IsSuccessful = true;
            return createCategoryProcessResult;
        }

        private async Task<bool> CheckCreateCategoryProcessIsValid(string categoryNameToCreate, ProcessResult proccessedResult)
        {
            Category categoryToCreate = await _categoryRepository.Get(p => p.Name == categoryNameToCreate);

            if (categoryToCreate != null)
            {
                proccessedResult.Message = Constants.CategoryService.CategoryToCreateAlreadyExist;
                return false;
            }
            return true;
        }
    }
}