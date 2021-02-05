using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class Category : MongoDBEntity
    {
        public string Name { get; set; }
    }
}