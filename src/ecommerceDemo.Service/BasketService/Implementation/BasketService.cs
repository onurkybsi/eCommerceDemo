using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ecommerceDemo.Data.Model;
using ecommerceDemo.Data.Repository;
using ecommerceDemo.Service.Common;
using Infrastructure;

namespace ecommerceDemo.Service
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductService _productService;

        public BasketService(IBasketRepository basketRepository, IProductService productService)
        {
            _basketRepository = basketRepository;
            _productService = productService;
        }

        public async Task<ProcessResult> AddToBasket(AddToBasketContext context)
        {
            ProcessResult addToBasketResult = new ProcessResult();

            Basket updatedBasket = await _basketRepository.Get(ba => ba.Id == context.BasketId);

            if (updatedBasket is null)
            {
                addToBasketResult.Message = Constants.BasketService.ThereIsNoSuchBasket;
                return addToBasketResult;
            }

            if (updatedBasket.IsOrdered)
            {
                addToBasketResult.Message = Constants.BasketService.BasketOrdered;
                return addToBasketResult;
            }

            Product addedProduct = await _productService.GetProduct(product => product.Id == context.ProductId);

            if (addedProduct is null)
            {
                addToBasketResult.Message = Constants.BasketService.BeAddedProductDoesntExist;
                return addToBasketResult;
            }

            updatedBasket.Products.Add(addedProduct);

            await _basketRepository.Update(updatedBasket);

            addToBasketResult.IsSuccessful = true;
            return addToBasketResult;
        }
    }
}