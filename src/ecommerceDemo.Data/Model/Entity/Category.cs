using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class Category : MongoDBEntity, IEntity
    {
        public string Name { get; set; }
    }
}