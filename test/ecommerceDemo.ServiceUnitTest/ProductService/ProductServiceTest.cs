using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;
using ecommerceDemo.Data.Repository;
using ecommerceDemo.Service;
using ecommerceDemo.Service.Common;
using Moq;
using Xunit;

namespace ecommerceDemo.ServiceUnitTest
{
    public class ProductServiceTest
    {
        private readonly IProductService _productService;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<ICategoryService> _mockCategoryService;

        public ProductServiceTest()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _mockCategoryService = new Mock<ICategoryService>();

            _productService = new ProductService(_mockProductRepository.Object, _mockCategoryService.Object);
        }

        [Fact]
        public async Task CreateProduct_When_ProductToCreate_Exist_Return_ProductToAddAlreadyExist_Message()
        {
            Product productToAdd = new Product
            {
                Name = "TestName",
                Price = 1,
                Description = "TestDescription",
                Category = new Category { Name = "TestCategory" }
            };

            _mockProductRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Product, bool>>>())).Returns(Task.FromResult(productToAdd));

            var response = await _productService.CreateProduct(new CreateProductContext
            { Name = productToAdd.Name, Price = productToAdd.Price, Description = productToAdd.Description, CategoryName = productToAdd.Category.Name });

            Assert.True(response.Message == Constants.ProductService.ProductToAddAlreadyExist);
        }

        [Fact]
        public async Task CreateProduct_When_Category_Doesnt_Exist_SuchInRequest_Return_ThereIsNoSuchCategory_Message()
        {
            Product productToAdd = new Product
            {
                Name = "TestName",
                Price = 1,
                Description = "TestDescription",
                Category = new Category { Name = "TestCategory" }
            };

            _mockProductRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Product, bool>>>())).Returns(Task.FromResult(default(Product)));
            _mockCategoryService.Setup(repo => repo.GetCategory(It.IsAny<Expression<Func<Category, bool>>>())).Returns(Task.FromResult(default(Category)));

            var response = await _productService.CreateProduct(new CreateProductContext
            { Name = productToAdd.Name, Price = productToAdd.Price, Description = productToAdd.Description, CategoryName = productToAdd.Category.Name });

            Assert.True(response.Message == Constants.ProductService.ThereIsNoSuchCategory);
        }

        [Fact]
        public async Task CreateProduct_When_ProductToCreate_Exist_And_Category__Exist_SuchInRequest_Return_IsSuccessTrue()
        {
            Product productToAdd = new Product
            {
                Name = "TestName",
                Price = 1,
                Description = "TestDescription",
                Category = new Category { Name = "TestCategory" }
            };

            _mockProductRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Product, bool>>>())).Returns(Task.FromResult(default(Product)));
            _mockCategoryService.Setup(repo => repo.GetCategory(It.IsAny<Expression<Func<Category, bool>>>())).Returns(Task.FromResult(productToAdd.Category));

            var response = await _productService.CreateProduct(new CreateProductContext
            { Name = productToAdd.Name, Price = productToAdd.Price, Description = productToAdd.Description, CategoryName = productToAdd.Category.Name });

            Assert.True(response.IsSuccessful);
        }
    }
}