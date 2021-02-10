namespace ecommerceDemo.Service.Common
{
    public static class Constants
    {
        public static class BasketService
        {
            public const string ThereIsNoSuchBasket = "ThereIsNoSuchBasket";
            public const string BasketOrdered = "BasketOrdered";
            public const string BeAddedProductDoesntExist = "BeAddedProductDoesntExist";
        }

        public static class UserService
        {
            public const string EmailAlreadyExist = "EmailAlreadyExist";
        }

        public static class ProductService
        {
            public const string ProductToAddAlreadyExist = "ProductToAddAlreadyExist";
            public const string ThereIsNoSuchCategory = "ThereIsNoSuchCategory";
        }

        public static class CategoryService
        {
            public const string CategoryToCreateAlreadyExist = "CategoryToCreateAlreadyExist";
        }
    }
}