using Infrastructure.Utility;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Host
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterModule(this IServiceCollection services, IModuleDescriptor moduleDescriptor)
        {
            moduleDescriptor.GetDescriptions().ForEach(description => services.Add(description));

            return services;
        }
    }
}