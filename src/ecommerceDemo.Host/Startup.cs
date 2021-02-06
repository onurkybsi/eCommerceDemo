using System.Collections.Generic;
using System.Linq;
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
            // RegisterModules(services);
            services.AddSingleton<ecommerceDemo.Data.Repository.MySQL.ecommerceDbContext>(sp => new Data.Repository.MySQL.ecommerceDbContext(new MySQLDatabaseSettings
            {
                ConnectionString = Configuration["ecommerceDemoDb_ConnectionStrings_MySQL"]
            }));
            services.AddSingleton<ecommerceDemo.Data.Repository.IProductRepository, ecommerceDemo.Data.Repository.MySQL.ProductRepository>(
                sp => new Data.Repository.MySQL.ProductRepository(sp.GetRequiredService<ecommerceDemo.Data.Repository.MySQL.ecommerceDbContext>())
            );
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Data.Utility.Initializer.ecommerceDb.InitializeRepository<Data.Model.Product>(Data.Model.DbType.MySQL, new List<Data.Model.Product>
            // {
            //     new Data.Model.Product
            //     {
            //         Name = "testProduct",
            //         Category = new Data.Model.Category
            //         {
            //             Name = "testCategory"
            //         }
            //     }
            // });

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var ctx = app.ApplicationServices.GetRequiredService<ecommerceDemo.Data.Repository.MySQL.ecommerceDbContext>();

            var test = ctx.Products.Where(p => p.Id == 1).FirstOrDefault();

            Serilog.Log.ForContext<Startup>().Information("{Application} is listening on {Env}...", Configuration["AppName"], env.EnvironmentName);
        }

        private void RegisterModules(IServiceCollection services)
        {
            services.RegisterModule(Data.Descriptor.GetDescriptor(new Data.Model.DataModuleContext
            {
                MongoDBSettings = new MongoDBSettings
                {
                    ConnectionString = Configuration["ecommerceDemoDb_ConnectionStrings_MongoDB"],
                    DatabaseName = Configuration["ecommerceDemoDb_DatabaseName"],
                },
                MySQLSettings = new MySQLDatabaseSettings
                {
                    ConnectionString = Configuration["ecommerceDemoDb_ConnectionStrings_MySQL"]
                },
                DbType = Data.Model.DbType.MySQL
            }));
        }
    }
}