using Infrastructure.Data;
using ecommerceDemo.Data.Model;
using System.Threading.Tasks;

namespace ecommerceDemo.Data.Repository.MongoDB
{
    public class ProductRepository : MongoDBCollectionBase<Model.MongoDBEntity.Product, Product>, IProductRepository
    {
        public ProductRepository(MongoDBCollectionSettings settings) : base(settings) { }

        public override Task Remove(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task Update(Product entity)
        {
            throw new System.NotImplementedException();
        }
    }
}