using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;
using ecommerceDemo.Data.Repository;

namespace ecommerceDemo.Service
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task CreateBasket(Basket basket)
            => await _basketRepository.Create(basket);

        public async Task FindAndUpdateBasket(Expression<Func<Basket, bool>> filterDefinition, Action<Basket> updateDefinition)
            => await _basketRepository.FindAndUpdate(filterDefinition, updateDefinition);

        public async Task<Basket> GetBasket(Expression<Func<Basket, bool>> filter)
            => await _basketRepository.Get(filter);

        public async Task<List<Basket>> GetBaskets(Expression<Func<Basket, bool>> filter = null)
            => await _basketRepository.GetList(filter);

        public async Task RemoveBasket(Basket basket)
            => await _basketRepository.Remove(basket);

        public async Task UpdateBasket(Basket basket)
            => await _basketRepository.Update(basket);
    }
}