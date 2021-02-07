using System.Collections.Generic;
using ecommerceDemo.Data.Model;
using ecommerceDemo.Data.Repository;
using Infrastructure.Data;
using Infrastructure.Utility;
using Microsoft.Extensions.DependencyInjection;

namespace ecommerceDemo.Data
{
    public class Descriptor : ModuleDescriptor<Data.Descriptor, DataModuleContext>
    {
        internal static DataModuleContext ModuleContext;

        public Descriptor(DataModuleContext dataModuleContext)
        {
            ModuleContext = dataModuleContext;
        }

        private static List<ServiceDescriptor> GetMongoDBCollectionDescriptions()
            => new List<ServiceDescriptor> {
                ServiceDescriptor.Singleton<IProductRepository, Repository.MongoDB.ProductRepository>(sp => new Repository.MongoDB.ProductRepository(
                    new MongoDBCollectionSettings
                    {
                        DatabaseSettings = ModuleContext.MongoDBSettings,
                        CollectionName = RepositoryContexts.ProductRepository.Name
                    }
                )),
                ServiceDescriptor.Singleton<IOrderRepository, Repository.MongoDB.OrderRepository>(sp => new Repository.MongoDB.OrderRepository(
                    new MongoDBCollectionSettings
                    {
                        DatabaseSettings = ModuleContext.MongoDBSettings,
                        CollectionName = RepositoryContexts.OrderRepository.Name
                    })),
                ServiceDescriptor.Singleton<ICategoryRepository, Repository.MongoDB.CategoryRepository>(sp => new Repository.MongoDB.CategoryRepository(
                    new MongoDBCollectionSettings
                    {
                        DatabaseSettings = ModuleContext.MongoDBSettings,
                        CollectionName = RepositoryContexts.CategoryRepository.Name
                    })),
                ServiceDescriptor.Singleton<IAddressRepository, Repository.MongoDB.AddressRepository>(sp => new Repository.MongoDB.AddressRepository(
                    new MongoDBCollectionSettings
                    {
                        DatabaseSettings = ModuleContext.MongoDBSettings,
                        CollectionName = RepositoryContexts.AddressRepository.Name
                    })),
                ServiceDescriptor.Singleton<IBasketRepository, Repository.MongoDB.BasketRepository>(sp => new Repository.MongoDB.BasketRepository(
                    new MongoDBCollectionSettings
                    {
                        DatabaseSettings = ModuleContext.MongoDBSettings,
                        CollectionName = RepositoryContexts.BasketRepository.Name
                    })),
                ServiceDescriptor.Singleton<IUserRepository, Repository.MongoDB.UserRepository>(sp => new Repository.MongoDB.UserRepository(
                    new MongoDBCollectionSettings
                    {
                        DatabaseSettings = ModuleContext.MongoDBSettings,
                        CollectionName = RepositoryContexts.UserRepository.Name
                    }))
            };

        // private static List<ServiceDescriptor> GetMySQLRepositoryDescriptions()
        // {
        //     Repository.MySQL.ecommerceDbContext context = new Repository.MySQL.ecommerceDbContext(ModuleContext.MySQLSettings);

        //     List<ServiceDescriptor> MySQLRepositoryDescriptions = new List<ServiceDescriptor>
        //     {
        //         ServiceDescriptor.Singleton<IProductRepository, Repository.MySQL.ProductRepository>(sp => new Repository.MySQL.ProductRepository(context)),
        //         ServiceDescriptor.Singleton<IOrderRepository, Repository.MySQL.OrderRepository>(sp => new Repository.MySQL.OrderRepository(context)),
        //         ServiceDescriptor.Singleton<ICategoryRepository, Repository.MySQL.CategoryRepository>(sp => new Repository.MySQL.CategoryRepository(context)),
        //         ServiceDescriptor.Singleton<IAddressRepository, Repository.MySQL.AddressRepository>(sp => new Repository.MySQL.AddressRepository(context)),
        //         ServiceDescriptor.Singleton<IBasketRepository, Repository.MySQL.BasketRepository>(sp => new Repository.MySQL.BasketRepository(context))
        //     };

        //     return MySQLRepositoryDescriptions;
        // }

        public override List<ServiceDescriptor> GetDescriptions()
        {
            // if (ModuleContext.DatabaseType == DatabaseType.MongoDB)
            // else
            //     return GetMySQLRepositoryDescriptions();
            return GetMongoDBCollectionDescriptions();
        }
    }
}