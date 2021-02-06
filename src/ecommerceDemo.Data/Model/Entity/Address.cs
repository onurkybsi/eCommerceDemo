using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class Address : Entity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public long Zip { get; set; }
        public string AddressDetail { get; set; }
    }
}