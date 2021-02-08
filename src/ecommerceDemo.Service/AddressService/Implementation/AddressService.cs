using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;
using ecommerceDemo.Data.Repository;

namespace ecommerceDemo.Service
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task CreateAddress(Address address)
            => await _addressRepository.Create(address);

        public async Task FindAndUpdateAddress(Expression<Func<Address, bool>> filterDefinition, Action<Address> updateDefinition)
            => await _addressRepository.FindAndUpdate(filterDefinition, updateDefinition);

        public async Task<Address> GetAddress(Expression<Func<Address, bool>> filter)
            => await _addressRepository.Get(filter);

        public async Task<List<Address>> GetAddresss(Expression<Func<Address, bool>> filter = null)
            => await _addressRepository.GetList(filter);

        public async Task RemoveAddress(Address address)
            => await _addressRepository.Remove(address);

        public async Task UpdateAddress(Address address)
            => await _addressRepository.Update(address);
    }
}