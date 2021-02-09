using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;
using ecommerceDemo.Data.Repository;

namespace ecommerceDemo.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateOrder(Order order)
            => await _orderRepository.Create(order);
        public async Task<Order> GetOrder(Expression<Func<Order, bool>> filter)
            => await _orderRepository.Get(filter);

        public async Task<List<Order>> GetOrders(Expression<Func<Order, bool>> filter = null)
            => await _orderRepository.GetList(filter);
    }
}