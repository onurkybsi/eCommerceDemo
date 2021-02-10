using Infrastructure.Data;
using ecommerceDemo.Data.Model;
using System.Threading.Tasks;

namespace ecommerceDemo.Data.Repository
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
        /// <summary>
        /// Create category.Return created category id.
        /// </summary>
        Task<string> CreateCategoryAndGetItsId(Category category);
    }
}