using Infrastructure.Data;
using ecommerceDemo.Data.Model;
using System.Threading.Tasks;

namespace ecommerceDemo.Data.Repository.MongoDB
{
    public class OrderRepository : MongoDBCollectionBase<Model.MongoDBEntity.Order, Order>, IOrderRepository
    {
        public OrderRepository(MongoDBCollectionSettings settings) : base(settings) { }

        public override Task Remove(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task Update(Order entity)
        {
            throw new System.NotImplementedException();
        }
    }
}