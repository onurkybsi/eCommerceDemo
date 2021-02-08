using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Service
{
    public interface IOrderService
    {
        Task<Order> GetOrder(Expression<Func<Order, bool>> filter);
        Task<List<Order>> GetOrders(Expression<Func<Order, bool>> filter = null);
        Task CreateOrder(Order order);
        Task UpdateOrder(Order order);
        Task FindAndUpdateOrder(Expression<Func<Order, bool>> filterDefinition, Action<Order> updateDefinition);
        Task RemoveOrder(Order order);
    }
}