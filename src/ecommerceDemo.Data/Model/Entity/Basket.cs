using System.Collections.Generic;
using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class Basket : IEntity
    {
        public object Id { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}