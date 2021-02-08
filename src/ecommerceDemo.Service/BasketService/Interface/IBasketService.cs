using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Service
{
    public interface IBasketService
    {
        Task<Basket> GetBasket(Expression<Func<Basket, bool>> filter);
        Task<List<Basket>> GetBaskets(Expression<Func<Basket, bool>> filter = null);
        Task CreateBasket(Basket basket);
        Task UpdateBasket(Basket basket);
        Task FindAndUpdateBasket(Expression<Func<Basket, bool>> filterDefinition, Action<Basket> updateDefinition);
        Task RemoveBasket(Basket basket);
    }
}