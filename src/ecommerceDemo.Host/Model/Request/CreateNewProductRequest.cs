namespace ecommerceDemo.Host.Model
{
    public class CreateNewProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
    }
}