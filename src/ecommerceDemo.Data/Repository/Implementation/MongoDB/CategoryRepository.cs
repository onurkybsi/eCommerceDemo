using Infrastructure.Data;
using ecommerceDemo.Data.Model;
using System.Threading.Tasks;

namespace ecommerceDemo.Data.Repository.MongoDB
{
    public class CategoryRepository : MongoDBCollectionBase<Model.MongoDBEntity.Category, Category>, ICategoryRepository
    {
        public CategoryRepository(MongoDBCollectionSettings settings) : base(settings) { }

        public override Task Remove(Category entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task Update(Category entity)
        {
            throw new System.NotImplementedException();
        }
    }
}