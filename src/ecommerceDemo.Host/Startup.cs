using Infrastructure.Data;
using Infrastructure.Host;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ecommerceDemo.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            RegisterModules(services);

            services.AddBasicJwtAuthentication(new Infrastructure.Host.Model.JwtAuthenticationContext
            {
                SecurityKey = Configuration["Jwt_SecurityKey"],
                Issuer = Configuration["Jwt_Issuer"],
                Audience = Configuration["Jwt_Audience"],
                Environment = Configuration.GetAspNetCoreEnvironment()
            });

            services.AddControllers().AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Serilog.Log.ForContext<Startup>().Information("{Application} is listening on {Env}...", Configuration["AppName"], env.EnvironmentName);
        }

        private void RegisterModules(IServiceCollection services)
        {
            services.RegisterModule(Data.Descriptor.GetDescriptor(new Data.Model.DataModuleContext
            {
                DatabaseType = Data.Model.DatabaseType.MongoDB,
                MongoDBSettings = new MongoDBSettings
                {
                    ConnectionString = Configuration["ecommerceDemoDb_ConnectionStrings_MongoDB"],
                    DatabaseName = Configuration["ecommerceDemoDb_DatabaseName"],
                },
                MySQLSettings = new MySQLDatabaseSettings
                {
                    ConnectionString = Configuration["ecommerceDemoDb_ConnectionStrings_MySQL"]
                }
            }));

            services.RegisterModule(Service.Descriptor.GetDescriptor(new Service.Model.ServiceModuleContext
            {
                JwtAuthenticationContext = new Infrastructure.Service.Model.JwtAuthenticationContext
                {
                    SecurityKey = Configuration["Jwt_SecurityKey"],
                    Issuer = Configuration["Jwt_Issuer"],
                    Audience = Configuration["Jwt_Audience"],
                    // GetUserAction =  
                }
          }));
        }
    }
}