using System.Threading.Tasks;
using Infrastructure.Model;

namespace ecommerceDemo.Service
{
    public interface IBasketService
    {
        Task<string> CreateNewBasket();
        Task<ProcessResult> AddProductToBasket(AddProductToBasketContext context);
    }
}