using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class Product : MongoDBEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }
}