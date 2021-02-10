using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;
using Infrastructure.Model;

namespace ecommerceDemo.Service
{
    public interface IProductService
    {
        Task<ProcessResult> CreateProduct(CreateProductContext context);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(string id);
    }
}