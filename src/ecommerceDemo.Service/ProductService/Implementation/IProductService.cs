using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Service
{
    public interface IProductService
    {
        Task<Product> GetProduct(Expression<Func<Product, bool>> filter);
        Task<List<Product>> GetProducts(Expression<Func<Product, bool>> filter = null);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task FindAndUpdateProduct(Expression<Func<Product, bool>> filterDefinition, Action<Product> updateDefinition);
        Task RemoveProduct(Product product);
    }
}