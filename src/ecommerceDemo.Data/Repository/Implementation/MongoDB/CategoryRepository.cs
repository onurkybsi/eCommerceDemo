using Infrastructure.Data;
using ecommerceDemo.Data.Model;
using System.Threading.Tasks;
using MongoDB.Bson;

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

        public async Task<string> CreateCategoryAndGetItsId(Category category)
        {
            string id = ObjectId.GenerateNewId().ToString();

            category.Id = id;

            await _collection.InsertOneAsync(category);
            return id;
        }
    }
}