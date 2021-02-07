using System.Threading.Tasks;
using ecommerceDemo.Data.Model;
using Infrastructure.Data;

namespace ecommerceDemo.Data.Repository.MongoDB
{
    public class BasketRepository : MongoDBCollectionBase<Model.MongoDBEntity.Basket, Model.Basket>, IBasketRepository
    {
        public BasketRepository(MongoDBCollectionSettings settings) : base(settings) { }

        public override Task Remove(Basket entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task Update(Basket entity)
        {
            throw new System.NotImplementedException();
        }
    }
}