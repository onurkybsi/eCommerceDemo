using System.Threading.Tasks;
using ecommerceDemo.Data.Model;
using Infrastructure.Data;

namespace ecommerceDemo.Data.Repository.MongoDB
{
    public class AddressRepository : MongoDBCollectionBase<Model.MongoDBEntity.Address, Model.Address>, IAddressRepository
    {
        public AddressRepository(MongoDBCollectionSettings settings) : base(settings) { }

        public override Task Remove(Address entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task Update(Address entity)
        {
            throw new System.NotImplementedException();
        }
    }
}