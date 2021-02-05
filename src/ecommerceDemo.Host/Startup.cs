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
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Serilog.Log.ForContext<Startup>().Information("{Application} is listening on {Env}...", Configuration["AppName"], env.EnvironmentName);
        }

        private void RegisterModules(IServiceCollection services)
        {
            services.RegisterModule(Data.Descriptor.GetDescriptor(new Data.DataModuleParameter
            {
                MongoDBSettings = new MongoDBSettings
                {
                    ConnectionString = Configuration["ecommerceDemoDb_ConnectionStrings"],
                    DatabaseName = Configuration["ecommerceDemoDb_DatabaseName"],
                }
            }));
        }
    }
}