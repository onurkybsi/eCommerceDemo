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
            List<ServiceDescriptor> serviceDescriptors = new List<ServiceDescriptor>
            {
                ServiceDescriptor.Singleton<IAuthenticationService, AuthenticationService>(sp => new AuthenticationService(ModuleContext.JwtAuthenticationContext))
            };

            return serviceDescriptors;
        }
    }
}