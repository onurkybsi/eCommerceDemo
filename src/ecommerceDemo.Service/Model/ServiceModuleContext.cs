using Infrastructure.Service;

namespace ecommerceDemo.Service.Model
{
    public class ServiceModuleContext
    {
        public JwtAuthenticationContext JwtAuthenticationContext { get; set; }
        public Data.Model.DataModuleContext DataModuleContext { get; set; }
    }
}