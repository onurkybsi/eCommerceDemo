using System.Collections.Generic;
using ecommerceDemo.Service.Model;
using Infrastructure.Utility;
using Microsoft.Extensions.DependencyInjection;

namespace ecommerceDemo.Service
{
    public class Descriptor : ModuleDescriptor<Service.Descriptor, ServiceModuleContext>
    {
        private readonly ServiceModuleContext ModuleContext;

        public Descriptor(ServiceModuleContext serviceModuleContext)
        {
            ModuleContext = serviceModuleContext;
        }
        public override List<ServiceDescriptor> GetDescriptions()
        {
            List<ServiceDescriptor> ServiceDescriptions = new List<ServiceDescriptor>();

            ServiceDescriptions.AddRange(GetDataModuleDescriptions());
            ServiceDescriptions.AddRange(GetDataServicesDescriptions());
            ServiceDescriptions.Add(ServiceDescriptor.Singleton<IAuthenticationService, AuthenticationService>(sp => new AuthenticationService(ModuleContext.JwtAuthenticationContext)));

            return ServiceDescriptions;
        }

        private List<ServiceDescriptor> GetDataModuleDescriptions()
            => ecommerceDemo.Data.Descriptor.GetDescriptor(ModuleContext.DataModuleContext).GetDescriptions();

        private List<ServiceDescriptor> GetDataServicesDescriptions()
            => new List<ServiceDescriptor>
            {
                ServiceDescriptor.Singleton<IAddressService, AddressService>(),
                ServiceDescriptor.Singleton<IBasketService, BasketService>(),
                ServiceDescriptor.Singleton<ICategoryService, CategoryService>(),
                ServiceDescriptor.Singleton<IOrderService, OrderService>(),
                ServiceDescriptor.Singleton<IProductService, ProductService>(),
                ServiceDescriptor.Singleton<IUserService, UserService>(),
            };
    }
}