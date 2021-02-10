using Infrastructure.Data;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Data.Repository.MongoDB
{
    public class UserRepository : MongoDBCollectionBase<User>, IUserRepository
    {
        public UserRepository(MongoDBCollectionSettings settings) : base(settings)
        {
            AddUniqueIndexForEmailIfNotExist();
        }

        private void AddUniqueIndexForEmailIfNotExist()
            => _collection.CreateUniqueIndex<Model.User>(nameof(Model.User.Email));
    }
}