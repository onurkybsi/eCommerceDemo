using Infrastructure.Data;

namespace ecommerceDemo.Data.Model
{
    public class User : IEntity
    {
        public object Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Token { get; set; }
    }
}