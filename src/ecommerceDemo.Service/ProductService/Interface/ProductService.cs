using System.Collections.Generic;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;
using ecommerceDemo.Data.Repository;
using ecommerceDemo.Service.Common;
using Infrastructure.Model;

namespace ecommerceDemo.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryService _categoryService;

        public ProductService(IProductRepository productRepository, ICategoryService categoryService)
        {
            _productRepository = productRepository;
            _categoryService = categoryService;
        }

        public async Task<ProcessResult> CreateProduct(CreateProductContext context)
        {
            ProcessResult createProductProcessResult = new ProcessResult();

            if (!(await CheckCreateProductProcessIsValid(context.Name, context.CategoryName, createProductProcessResult)))
                return createProductProcessResult;

            Product productToCreate = new Product
            {
                Name = context.Name,
                Price = context.Price,
                Description = context.Description,
                Category = new Category { Name = context.CategoryName }
            };

            await _productRepository.Create(productToCreate);

            createProductProcessResult.IsSuccessful = true;
            return createProductProcessResult;
        }

        private async Task<bool> CheckCreateProductProcessIsValid(string productName, string categoryName, ProcessResult proccessedResult)
        {
            Product productToCreate = await _productRepository.Get(p => p.Name == productName);

            if (productToCreate != null)
            {
                proccessedResult.Message = Constants.ProductService.ProductToAddAlreadyExist;
                return false;
            }

            Category categoryOfProduct = await _categoryService.GetCategory(c => c.Name == categoryName);

            if (categoryOfProduct is null)
            {
                proccessedResult.Message = Constants.ProductService.ThereIsNoSuchCategory;
                return false;
            }
            return true;
        }

        public async Task<List<Product>> GetAllProducts()
            => await _productRepository.GetList();

        public async Task<Product> GetProductById(string id)
            => await _productRepository.Get(p => p.Id == id);
    }
}