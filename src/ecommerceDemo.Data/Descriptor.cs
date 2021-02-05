using System.Collections.Generic;
using ecommerceDemo.Data.Repository;
using Infrastructure.Data;
using Infrastructure.Utility;
using Microsoft.Extensions.DependencyInjection;

namespace ecommerceDemo.Data
{
    public class Descriptor : ModuleDescriptor<Data.Descriptor, DataModuleParameter>
    {
        private static DataModuleParameter ModuleParameter;

        public Descriptor(DataModuleParameter dataModuleParameter)
        {
            ModuleParameter = dataModuleParameter;
        }

        private static List<ServiceDescriptor> MongoDBCollectionDescriptions = new List<ServiceDescriptor>
        {
            ServiceDescriptor.Singleton<IProductRepository, ProductRepository>(sp => new ProductRepository(
                new MongoDBCollectionSettings
                {
                    DatabaseSettings = ModuleParameter.MongoDBSettings,
                    CollectionName = "Product"
                }
            )),
            ServiceDescriptor.Singleton<IOrderRepository, OrderRepository>(sp => new OrderRepository(
                new MongoDBCollectionSettings
                {
                    DatabaseSettings = ModuleParameter.MongoDBSettings,
                    CollectionName = "Order"
                })),
            ServiceDescriptor.Singleton<ICategoryRepository, CategoryRepository>(sp => new CategoryRepository(
                new MongoDBCollectionSettings
                {
                    DatabaseSettings = ModuleParameter.MongoDBSettings,
                    CollectionName = "Category"
                })),
            ServiceDescriptor.Singleton<IAddressRepository, AddressRepository>(sp => new AddressRepository(
                new MongoDBCollectionSettings
                {
                    DatabaseSettings = ModuleParameter.MongoDBSettings,
                    CollectionName = "Address"
                })),
            ServiceDescriptor.Singleton<IBasketRepository, BasketRepository>(sp => new BasketRepository(
                new MongoDBCollectionSettings
                {
                    DatabaseSettings = ModuleParameter.MongoDBSettings,
                    CollectionName = "Basket"
                })),
        };

        private static List<ServiceDescriptor> Descriptions = new List<ServiceDescriptor>();

        public override List<ServiceDescriptor> GetDescriptions()
        {
            Descriptions.AddRange(MongoDBCollectionDescriptions);

            return Descriptions;
        }
    }

    public class DataModuleParameter
    {
        public MongoDBSettings MongoDBSettings { get; set; }
    }
}