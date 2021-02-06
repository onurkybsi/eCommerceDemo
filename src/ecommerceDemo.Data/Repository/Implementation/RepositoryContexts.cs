using MongoDB.Driver;

namespace ecommerceDemo.Data.Repository
{
    internal static class RepositoryContexts
    {
        public static class UserRepository
        {
            public static string Name = "User";
            public static CreateCollectionOptions MongoDBCreateCollectionOptions = null;
        }
        public static class ProductRepository
        {
            public static string Name = "Product";
            public static CreateCollectionOptions MongoDBCreateCollectionOptions = null;
        }
        public static class CategoryRepository
        {
            public static string Name = "Category";
            public static CreateCollectionOptions MongoDBCreateCollectionOptions = null;
        }
        public static class BasketRepository
        {
            public static string Name = "Basket";
            public static CreateCollectionOptions MongoDBCreateCollectionOptions = null;
        }
        public static class OrderRepository
        {
            public static string Name = "Order";
            public static CreateCollectionOptions MongoDBCreateCollectionOptions = null;
        }
        public static class AddressRepository
        {
            public static string Name = "Address";
            public static CreateCollectionOptions MongoDBCreateCollectionOptions = null;
        }
    }
}