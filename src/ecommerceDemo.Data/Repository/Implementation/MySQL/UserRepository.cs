using Infrastructure.Data;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Data.Repository.MySQL
{
    public class UserRepository : MySQLRepositoryBase<User>, IUserRepository
    {
        public UserRepository(ecommerceDbContext context) : base(context) { }
    }
}