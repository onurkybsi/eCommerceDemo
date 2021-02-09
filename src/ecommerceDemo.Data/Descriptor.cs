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

        public override List<ServiceDescriptor> GetDescriptions()
            => GetMongoDBCollectionDescriptions();
    }
}