using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class Category : IEntity
    {
        public object Id { get; set; }
        public string Name { get; set; }
    }
}