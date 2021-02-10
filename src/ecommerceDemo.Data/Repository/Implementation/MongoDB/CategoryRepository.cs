using Infrastructure.Data;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Data.Repository.MongoDB
{
    public class CategoryRepository : MongoDBCollectionBase<Category>, ICategoryRepository
    {
        public CategoryRepository(MongoDBCollectionSettings settings) : base(settings)
        {
            AddUniqueIndexForProductNameIfNotExist();
        }

        public void AddUniqueIndexForProductNameIfNotExist()
           => _collection.CreateUniqueIndex<Model.Category>(nameof(Model.Product.Name));
    }
}