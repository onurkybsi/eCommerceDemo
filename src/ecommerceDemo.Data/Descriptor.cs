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
        private static DataModuleContext _dataModuleContext;

        public Descriptor(DataModuleContext dataModuleContext)
        {
            _dataModuleContext = dataModuleContext;
        }

        private static List<ServiceDescriptor> MongoDBCollectionDescriptions = new List<ServiceDescriptor>
        {
            ServiceDescriptor.Singleton<IProductRepository, Repository.MongoDB.ProductRepository>(sp => new Repository.MongoDB.ProductRepository(
                new MongoDBCollectionSettings
                {
                    DatabaseSettings = _dataModuleContext.MongoDBSettings,
                    CollectionName = "Product"
                }
            )),
            ServiceDescriptor.Singleton<IOrderRepository, Repository.MongoDB.OrderRepository>(sp => new Repository.MongoDB.OrderRepository(
                new MongoDBCollectionSettings
                {
                    DatabaseSettings = _dataModuleContext.MongoDBSettings,
                    CollectionName = "Order"
                })),
            ServiceDescriptor.Singleton<ICategoryRepository, Repository.MongoDB.CategoryRepository>(sp => new Repository.MongoDB.CategoryRepository(
                new MongoDBCollectionSettings
                {
                    DatabaseSettings = _dataModuleContext.MongoDBSettings,
                    CollectionName = "Category"
                })),
            ServiceDescriptor.Singleton<IAddressRepository, Repository.MongoDB.AddressRepository>(sp => new Repository.MongoDB.AddressRepository(
                new MongoDBCollectionSettings
                {
                    DatabaseSettings = _dataModuleContext.MongoDBSettings,
                    CollectionName = "Address"
                })),
            ServiceDescriptor.Singleton<IBasketRepository, Repository.MongoDB.BasketRepository>(sp => new Repository.MongoDB.BasketRepository(
                new MongoDBCollectionSettings
                {
                    DatabaseSettings = _dataModuleContext.MongoDBSettings,
                    CollectionName = "Basket"
                })),
        };

        private static List<ServiceDescriptor> MySQLRepositoryDescriptions = new List<ServiceDescriptor>
        {
            ServiceDescriptor.Singleton<IProductRepository, Repository.MySQL.ProductRepository>(sp => new Repository.MySQL.ProductRepository(sp.GetRequiredService<Repository.MySQL.ecommerceDbContext>())),
            ServiceDescriptor.Singleton<IOrderRepository, Repository.MySQL.OrderRepository>(sp => new Repository.MySQL.OrderRepository(sp.GetRequiredService<Repository.MySQL.ecommerceDbContext>())),
            ServiceDescriptor.Singleton<ICategoryRepository, Repository.MySQL.CategoryRepository>(sp => new Repository.MySQL.CategoryRepository(sp.GetRequiredService<Repository.MySQL.ecommerceDbContext>())),
            ServiceDescriptor.Singleton<IAddressRepository, Repository.MySQL.AddressRepository>(sp => new Repository.MySQL.AddressRepository(sp.GetRequiredService<Repository.MySQL.ecommerceDbContext>())),
            ServiceDescriptor.Singleton<IBasketRepository, Repository.MySQL.BasketRepository>(sp => new Repository.MySQL.BasketRepository(sp.GetRequiredService<Repository.MySQL.ecommerceDbContext>()))
        };

        private static List<ServiceDescriptor> Descriptions = new List<ServiceDescriptor>
        {
            ServiceDescriptor.Singleton<Repository.MySQL.ecommerceDbContext>(sp => new Repository.MySQL.ecommerceDbContext(_dataModuleContext.MySQLSettings))
        };

        public override List<ServiceDescriptor> GetDescriptions()
        {
            if (_dataModuleContext.DbType == DbType.MongoDB)
            {
                Descriptions.AddRange(MongoDBCollectionDescriptions);
            }
            else
            {
                Descriptions.AddRange(MySQLRepositoryDescriptions);

            }

            return Descriptions;
        }
    }
}