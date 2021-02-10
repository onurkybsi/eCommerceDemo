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

        public async Task<string> CreateNewBasket()
            => await _basketRepository.Create();

        public async Task<ProcessResult> AddProductToBasket(AddProductToBasketContext context)
        {
            ProcessResult addToBasketResult = new ProcessResult();

            Product productToAdd = await _productService.GetProductById(context.ProductId);

            if (!CheckProductToAddIsValid(productToAdd, addToBasketResult))
                return addToBasketResult;

            Basket targetBasket = (await _basketRepository.Get(ba => ba.Id == context.BasketId && ba.IsOrdered == false));

            if (targetBasket is null)
            {
                addToBasketResult.Message = Constants.BasketService.ThereIsNoSuchBasket;
                return addToBasketResult;
            }
            else
            {
                if (!CheckBasketIsValidToUpdate(targetBasket, addToBasketResult))
                    return addToBasketResult;

                await UpdateBasketWithProduct(targetBasket, productToAdd);
                addToBasketResult.IsSuccessful = true;
            }

            return addToBasketResult;
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

        private bool CheckBasketIsValidToUpdate(Basket basketToAdd, ProcessResult proccessedResult)
        {
            bool isValid = true;

            if (basketToAdd.IsOrdered)
            {
                proccessedResult.Message = Constants.BasketService.BasketOrdered;
                isValid = false;
            }

            return isValid;
        }

        private async Task UpdateBasketWithProduct(Basket basketToUpdate, Product newProduct)
        {
            basketToUpdate.Products.Add(newProduct);

            await _basketRepository.Update(basketToUpdate);
        }
    }
}