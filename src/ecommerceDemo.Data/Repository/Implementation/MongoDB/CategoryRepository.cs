using Infrastructure.Data;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Data.Repository.MongoDB
{
    public class CategoryRepository : MongoDBCollectionBase<Category>, ICategoryRepository
    {
        public CategoryRepository(MongoDBCollectionSettings settings) : base(settings) { }
    }
}