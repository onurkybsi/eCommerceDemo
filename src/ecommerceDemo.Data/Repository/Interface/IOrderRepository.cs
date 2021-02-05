using Infrastructure.Data;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Data.Repository
{
    public interface IOrderRepository : IEntityRepository<Order> { }
}