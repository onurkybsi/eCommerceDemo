using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;
using ecommerceDemo.Data.Repository;

namespace ecommerceDemo.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateProduct(Product product)
            => await _productRepository.Create(product);

        public async Task FindAndUpdateProduct(Expression<Func<Product, bool>> filterDefinition, Action<Product> updateDefinition)
            => await _productRepository.FindAndUpdate(filterDefinition, updateDefinition);

        public async Task<Product> GetProduct(Expression<Func<Product, bool>> filter)
            => await _productRepository.Get(filter);

        public async Task<List<Product>> GetProducts(Expression<Func<Product, bool>> filter = null)
            => await _productRepository.GetList(filter);

        public async Task RemoveProduct(Product product)
            => await _productRepository.Remove(product);

        public async Task UpdateProduct(Product product)
            => await _productRepository.Update(product);
    }
}