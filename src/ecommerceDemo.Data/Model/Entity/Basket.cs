using System.Collections.Generic;
using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class Basket : Entity
    {
        public ICollection<Product> Products { get; set; } 
    }
}