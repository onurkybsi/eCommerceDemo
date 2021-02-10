using System;
using System.Collections.Generic;
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
    public class BasketServiceTest
    {
        private readonly IBasketService _basketService;
        private readonly Mock<IBasketRepository> _mockBasketRepository;
        private readonly Mock<IProductService> _mockProductService;

        public BasketServiceTest()
        {
            _mockBasketRepository = new Mock<IBasketRepository>();
            _mockProductService = new Mock<IProductService>();

            _basketService = new BasketService(_mockBasketRepository.Object, _mockProductService.Object);
        }

        [Fact]
        public async Task AddProductToBasket_When_ProductToAdded_Doenst_Exist_Return_BeAddedProductDoesntExist_Message()
        {
            _mockProductService.Setup(repo => repo.GetProductById("productId")).Returns(Task.FromResult(default(Product)));

            var response = await _basketService.AddProductToBasket(new AddProductToBasketContext
            {
                BasketId = "basketId",
                ProductId = "productId"
            });

            Assert.True(response.Message == Constants.BasketService.BeAddedProductDoesntExist);
        }

        [Fact]
        public async Task AddProductToBasket_When_Basket_NotYet_Created_Return_ThereIsNoSuchBasket_Message()
        {
            _mockProductService.Setup(repo => repo.GetProductById("productId")).Returns(Task.FromResult(new Product { Id = "productId", Name = "SomeProduct" }));

            _mockBasketRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Basket, bool>>>())).Returns(Task.FromResult(default(Basket)));

            var response = await _basketService.AddProductToBasket(new AddProductToBasketContext
            {
                BasketId = "basketId",
                ProductId = "productId"
            });

            Assert.True(response.Message == Constants.BasketService.ThereIsNoSuchBasket);
        }

        [Fact]
        public async Task AddProductToBasket_When_RequestedBasket_Ordered_Return_BasketOrdered_Message()
        {
            _mockProductService.Setup(repo => repo.GetProductById("productId")).Returns(Task.FromResult(new Product { Id = "productId", Name = "SomeProduct" }));

            _mockBasketRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Basket, bool>>>())).Returns(Task.FromResult(new Basket { Id = "basketId", IsOrdered = true }));

            var response = await _basketService.AddProductToBasket(new AddProductToBasketContext
            {
                BasketId = "basketId",
                ProductId = "productId"
            });

            Assert.True(response.Message == Constants.BasketService.BasketOrdered);
        }

        [Fact]
        public async Task AddProductToBasket_When_RequestValid_Call_BasketRepository_Update()
        {
            _mockProductService.Setup(repo => repo.GetProductById("productId")).Returns(Task.FromResult(new Product { Id = "productId", Name = "SomeProduct" }));

            _mockBasketRepository.Setup(repo => repo.Get(It.IsAny<Expression<Func<Basket, bool>>>()))
                .Returns(Task.FromResult(new Basket { Id = "basketId", Products = new List<Product>() }));

            _mockBasketRepository.Setup(repo => repo.Update(It.IsAny<Basket>()));

            var response = await _basketService.AddProductToBasket(new AddProductToBasketContext
            {
                BasketId = "basketId",
                ProductId = "productId"
            });

            _mockBasketRepository.Verify(repo => repo.Update(It.IsAny<Basket>()), Times.Once);
        }
    }
}