using Infrastructure.Data;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Data.Repository.MongoDB
{
    public class AddressRepository : MongoDBCollectionBase<Address>, IAddressRepository
    {
        public AddressRepository(MongoDBCollectionSettings settings) : base(settings) { }
    }
}