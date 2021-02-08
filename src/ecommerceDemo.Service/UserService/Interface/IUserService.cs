using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;

namespace ecommerceDemo.Service
{
    public interface IUserService 
    {
        Task<User> GetUser(Expression<Func<User, bool>> filter);
        Task<List<User>> GetUsers(Expression<Func<User, bool>> filter = null);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task FindAndUpdateUser(Expression<Func<User, bool>> filterDefinition, Action<User> updateDefinition);
        Task RemoveUser(User user);
    }
}