using Infrastructure.Data;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Data.Repository
{
    public class AddressRepository : MongoDBCollectionBase<Address>, IAddressRepository
    {
        public AddressRepository(MongoDBCollectionSettings settings) : base(settings) { }
    }
}