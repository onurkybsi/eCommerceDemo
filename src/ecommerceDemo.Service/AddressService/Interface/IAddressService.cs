using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Service
{
    public interface IAddressService
    {
        Task<Address> GetAddress(Expression<Func<Address, bool>> filter);
        Task<List<Address>> GetAddresss(Expression<Func<Address, bool>> filter = null);
        Task CreateAddress(Address address);
        Task UpdateAddress(Address address);
        Task FindAndUpdateAddress(Expression<Func<Address, bool>> filterDefinition, Action<Address> updateDefinition);
        Task RemoveAddress(Address address);
    }
}