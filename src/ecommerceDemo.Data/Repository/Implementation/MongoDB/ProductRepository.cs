using Infrastructure.Data;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Data.Repository.MongoDB
{
    public class ProductRepository : MongoDBCollectionBase<Product>, IProductRepository
    {
        public ProductRepository(MongoDBCollectionSettings settings) : base(settings) { }
    }
}