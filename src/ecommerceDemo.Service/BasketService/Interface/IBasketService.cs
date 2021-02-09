using System.Threading.Tasks;
using Infrastructure;

namespace ecommerceDemo.Service
{
    public interface IBasketService
    {
        Task<ProcessResult> AddToBasket(AddToBasketContext context);
    }
}