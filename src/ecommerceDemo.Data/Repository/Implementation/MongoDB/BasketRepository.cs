using Infrastructure.Data;
using ecommerceDemo.Data.Model;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ecommerceDemo.Data.Repository.MongoDB
{
    public class BasketRepository : MongoDBCollectionBase<Basket>, IBasketRepository
    {
        public BasketRepository(MongoDBCollectionSettings settings) : base(settings) { }

        public async Task<string> Create()
        {
            string id = ObjectId.GenerateNewId().ToString();

            Basket basket = new Basket
            {
                Id = id
            };

            await _collection.InsertOneAsync(basket);
            return id;
        }
    }
}