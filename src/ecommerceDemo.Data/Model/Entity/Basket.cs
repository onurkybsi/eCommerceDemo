using System.Collections.Generic;
using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class Basket : MongoDBEntity, IEntity
    {
        public ICollection<Product> Products { get; set; } 
    }
}