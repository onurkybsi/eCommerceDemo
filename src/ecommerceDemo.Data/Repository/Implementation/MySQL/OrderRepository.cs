using Infrastructure.Data;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Data.Repository.MySQL
{
    public class OrderRepository : MySQLRepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ecommerceDbContext context) : base(context) { }
    }
}