using Infrastructure.Data;
using ecommerceDemo.Data.Model;
using System.Threading.Tasks;

namespace ecommerceDemo.Data.Repository.MongoDB
{
    public class UserRepository : MongoDBCollectionBase<Model.MongoDBEntity.User, User>, IUserRepository
    {
        public UserRepository(MongoDBCollectionSettings settings) : base(settings) { }

        public override Task Remove(User entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task Update(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}