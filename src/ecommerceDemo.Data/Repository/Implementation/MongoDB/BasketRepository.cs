using Infrastructure.Data;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Data.Repository
{
    public class BasketRepository : MongoDBCollectionBase<Basket>, IBasketRepository
    {
        public BasketRepository(MongoDBCollectionSettings settings) : base(settings) { }
    }
}