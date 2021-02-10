using Infrastructure.Data;
using ecommerceDemo.Data.Model;
using System.Threading.Tasks;

namespace ecommerceDemo.Data.Repository
{
    public interface IBasketRepository : IEntityRepository<Basket>
    {
        /// <summary>
        /// Create basket.Return created basket id.
        /// </summary>
        Task<string> Create();
    }
}