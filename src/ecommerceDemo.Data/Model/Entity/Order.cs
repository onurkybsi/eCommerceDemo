using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class Order : Entity
    {
        public User Owner { get; set; }
        public Basket Basket { get; set; }
        public Address Address { get; set; }
        public bool Shipped { get; set; }
    }
}