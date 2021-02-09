using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;
using ecommerceDemo.Data.Repository;
using ecommerceDemo.Service.Common;
using Infrastructure.Model;

namespace ecommerceDemo.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ProcessResult> CreateUser(User user)
        {
            ProcessResult createUserProcessResult= new ProcessResult();

            bool userExistByEmail = await _userRepository.Get(u => u.Email == user.Email) != null;

            if(userExistByEmail) 
            {
                createUserProcessResult.Message = Constants.UserService.EmailAlreadyExist;
                return createUserProcessResult;
            }

            await _userRepository.Create(user);

            createUserProcessResult.IsSuccessful = true;
            return createUserProcessResult;
        }

        public async Task FindAndUpdateUser(Expression<Func<User, bool>> filterDefinition, Action<User> updateDefinition)
            => await _userRepository.FindAndUpdate(filterDefinition, updateDefinition);

        public async Task<User> GetUser(Expression<Func<User, bool>> filter)
            => await _userRepository.Get(filter);

        public async Task<List<User>> GetUsers(Expression<Func<User, bool>> filter = null)
            => await _userRepository.GetList(filter);

        public async Task RemoveUser(User user)
            => await _userRepository.Remove(user);

        public async Task UpdateUser(User user)
            => await _userRepository.Update(user);
    }
}