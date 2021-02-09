using System.Collections.Generic;
using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class Basket : MongoDBEntity, IEntity
    {
        public bool IsOrdered { get; set; }
        public ICollection<Product> Products { get; set; } 
    }
}