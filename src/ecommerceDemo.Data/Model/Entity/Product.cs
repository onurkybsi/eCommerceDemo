using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class Product : IEntity
    {
        public object Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }
}