using Infrastructure.Data;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Data.Repository.MySQL
{
    public class AddressRepository : MySQLRepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(ecommerceDbContext context) : base(context) { }
    }
}