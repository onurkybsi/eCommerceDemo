using System;
using Infrastructure.Data;
using MongoDB.Driver;

namespace ecommerceDemo.Data.Repository
{
    // MongoDBBase'e indirilmeli
    internal static class RepositoryContexts
    {
        public static class UserRepository
        {
            public static string Name = "User";
            public static CreateCollectionOptions MongoDBCreateCollectionOptions = null;
            public static Action<IMongoCollection<Model.User>> InitialAction = (collection) => collection.CreateUniqueIndex(nameof(Model.User.Email));
        }

        public static class ProductRepository
        {
            public static string Name = "Product";
            public static CreateCollectionOptions MongoDBCreateCollectionOptions = null;
            public static Action<IMongoCollection<Model.Product>> InitialAction = (collection) => collection.CreateUniqueIndex(nameof(Model.Product.Name));
        }

        public static class CategoryRepository
        {
            public static string Name = "Category";
            public static CreateCollectionOptions MongoDBCreateCollectionOptions = null;
            public static Action<IMongoCollection<Model.Category>> InitialAction = (collection) => collection.CreateUniqueIndex(nameof(Model.Category.Name));
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

        public static string GetCollectionNameByEntityType<TEntity>()
        {
            if (typeof(TEntity) == typeof(Data.Model.Product))
                return RepositoryContexts.ProductRepository.Name;
            else if (typeof(TEntity) == typeof(Data.Model.Category))
                return RepositoryContexts.CategoryRepository.Name;
            else if (typeof(TEntity) == typeof(Data.Model.Basket))
                return RepositoryContexts.BasketRepository.Name;
            else if (typeof(TEntity) == typeof(Data.Model.Address))
                return RepositoryContexts.AddressRepository.Name;
            else if (typeof(TEntity) == typeof(Data.Model.Order))
                return RepositoryContexts.OrderRepository.Name;
            else if (typeof(TEntity) == typeof(Data.Model.User))
                return RepositoryContexts.UserRepository.Name;

            return string.Empty;
        }

        public static CreateCollectionOptions GetMongoDBCreateCollectionOptionsByEntityType<TEntity>()
        {
            if (typeof(TEntity) == typeof(Data.Model.Product))
                return RepositoryContexts.ProductRepository.MongoDBCreateCollectionOptions;
            else if (typeof(TEntity) == typeof(Data.Model.Category))
                return RepositoryContexts.CategoryRepository.MongoDBCreateCollectionOptions;
            else if (typeof(TEntity) == typeof(Data.Model.Basket))
                return RepositoryContexts.BasketRepository.MongoDBCreateCollectionOptions;
            else if (typeof(TEntity) == typeof(Data.Model.Address))
                return RepositoryContexts.AddressRepository.MongoDBCreateCollectionOptions;
            else if (typeof(TEntity) == typeof(Data.Model.Order))
                return RepositoryContexts.OrderRepository.MongoDBCreateCollectionOptions;
            else if (typeof(TEntity) == typeof(Data.Model.User))
                return RepositoryContexts.UserRepository.MongoDBCreateCollectionOptions;

            return new CreateCollectionOptions();
        }

        public static Action<IMongoCollection<TEntity>> GetInitialActionByEntityType<TEntity>() where TEntity : IEntity
        {
            if (typeof(TEntity) == typeof(Data.Model.User))
                return RepositoryContexts.UserRepository.InitialAction as Action<IMongoCollection<TEntity>>;

            return null;
        }
    }
}