using System.Collections.Generic;
using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class Basket : MongoDBEntity
    {
        public List<Product> Products { get; set; }
    }
}