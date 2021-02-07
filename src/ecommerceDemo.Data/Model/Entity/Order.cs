using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class Order : IEntity
    {
        public object Id { get; set; }
        public User Owner { get; set; }
        public Basket Basket { get; set; }
        public Address Address { get; set; }
        public bool Shipped { get; set; }
    }
}