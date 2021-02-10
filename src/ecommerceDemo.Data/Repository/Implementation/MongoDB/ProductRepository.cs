using Infrastructure.Data;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Data.Repository.MongoDB
{
    public class ProductRepository : MongoDBCollectionBase<Product>, IProductRepository
    {
        public ProductRepository(MongoDBCollectionSettings settings) : base(settings)
        {
            AddUniqueIndexForProductNameIfNotExist();
        }

        public void AddUniqueIndexForProductNameIfNotExist()
           => _collection.CreateUniqueIndex<Model.Product>(nameof(Model.Product.Name));
    }
}