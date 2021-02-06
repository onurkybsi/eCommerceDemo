using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class Order : Entity
    {
        public Basket Basket { get; set; }
        public bool Shipped { get; set; }
        public Address Address { get; set; }
        public bool GiftWrap { get; set; }
    }
}