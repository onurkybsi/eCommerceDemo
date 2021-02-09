using System.Threading.Tasks;
using ecommerceDemo.Data.Model;
using ecommerceDemo.Data.Repository;
using ecommerceDemo.Service.Common;
using Infrastructure.Model;

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

        public async Task<ProcessResult> AddProductToBasket(AddProductToBasketContext context)
        {
            ProcessResult addToBasketResult = new ProcessResult();

            Basket targetBasket = await _basketRepository.Get(ba => ba.Id == context.BasketId);

            if (!CheckBasketIsValidToAdd(targetBasket, addToBasketResult))
                return addToBasketResult;

            Product productToAdd = await _productService.GetProduct(product => product.Id == context.ProductId);

            if (!CheckProductToAddIsValid(productToAdd, addToBasketResult))
                return addToBasketResult;

            await UpdateBasketWithNewProduct(targetBasket, productToAdd);
            addToBasketResult.IsSuccessful = true;

            return addToBasketResult;
        }

        private bool CheckBasketIsValidToAdd(Basket basketToAdd, ProcessResult proccessedResult)
        {
            bool isValid = true;

            if (basketToAdd is null)
            {
                proccessedResult.Message = Constants.BasketService.ThereIsNoSuchBasket;
                isValid = false;
            }
            else if (basketToAdd.IsOrdered)
            {
                proccessedResult.Message = Constants.BasketService.BasketOrdered;
                isValid = false;
            }

            return isValid;
        }

        private bool CheckProductToAddIsValid(Product productToAdd, ProcessResult proccessedResult)
        {
            bool isValid = true;

            if (productToAdd is null)
            {
                proccessedResult.Message = Constants.BasketService.BeAddedProductDoesntExist;
                isValid = false;
            }

            return isValid;
        }

        private async Task UpdateBasketWithNewProduct(Basket basket, Product product)
        {
            basket.Products.Add(product);

            await _basketRepository.Update(basket);
        }
    }
}