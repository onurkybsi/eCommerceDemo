using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Utility
{
    /// <summary>
    /// Generic abstract IModuleDescriptor base implementation
    /// </summary>
    public abstract class ModuleDescriptor<TModule, TModuleParameter> : IModuleDescriptor
    {
        protected static TModule instance;

        protected ModuleDescriptor() { }

        /// <summary>
        /// Creates the described module descriptor and returns.
        /// </summary>
        /// <returns>
        /// Returns the described module descriptor
        /// </returns>
        public static TModule GetDescriptor(TModuleParameter moduleParameter)
            => instance ?? (instance = (TModule)Activator.CreateInstance(typeof(TModule), moduleParameter));

        public abstract List<ServiceDescriptor> GetDescriptions();

        public IServiceCollection Describe(IServiceCollection services)
        {
            GetDescriptions()?.ForEach(d => services.Add(d));

            return services;
        }
    }
}