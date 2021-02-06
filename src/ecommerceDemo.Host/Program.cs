using System;
using System.Collections.Generic;
using System.IO;
using Infrastructure.Host;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ecommerceDemo.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = InitialHelper.GetConfiguration(Directory.GetCurrentDirectory(), System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));

            Log.Logger = InitialHelper.CreateELKLogger(new ELKLoggerSettings
            {
                AppName = configuration["AppName"],
                ElasticsearchURL = configuration["ElasticsearchURL"]
            });

            var host = CreateHostBuilder(args, configuration).Build();

            InitializeDatabase();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration)
            => Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel(options => options.AddServerHeader = false);
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(config => config.ClearProviders()).UseSerilog();

        private static void InitializeDatabase()
        {
            var exampleUser = new Data.Model.User
            {
                FirstName = "Onur",
                LastName = "Kayabasi",
                Email = "onurbpm@outlook.com",
            };

            Data.Utility.Initializer.ecommerceDb.InitializeRepository<Data.Model.User>(new List<Data.Model.User>
            {
                exampleUser
            });

            var laptopCategory = new Data.Model.Category
            {
                Name = "Laptop"
            };

            Data.Utility.Initializer.ecommerceDb.InitializeRepository<Data.Model.Category>(new List<Data.Model.Category>
            {
                laptopCategory
            });

            var msiProduct = new Data.Model.Product
            {
                Name = "MSI GP62 7RD",
                Description = "Description of MSI GP62 7RD",
                Price = 7000,
                Category = laptopCategory
            };

            Data.Utility.Initializer.ecommerceDb.InitializeRepository<Data.Model.Product>(new List<Data.Model.Product>
            {
                msiProduct
            });

            var exampleBasket = new Data.Model.Basket
            {
                Products = new List<Data.Model.Product>
                {
                    msiProduct
                }
            };

            Data.Utility.Initializer.ecommerceDb.InitializeRepository<Data.Model.Basket>(new List<Data.Model.Basket>
            {
                exampleBasket
            });

            var exampleAddress = new Data.Model.Address
            {
                Country = "Turkey",
                City = "Istanbul",
                District = "Pendik",
                Zip = 34909
            };

            Data.Utility.Initializer.ecommerceDb.InitializeRepository<Data.Model.Address>(new List<Data.Model.Address>
            {
                exampleAddress
            });

            Data.Utility.Initializer.ecommerceDb.InitializeRepository<Data.Model.Order>(new List<Data.Model.Order>
            {
                new Data.Model.Order
                {
                    Owner = exampleUser,
                    Basket = exampleBasket,
                    Address = exampleAddress,
                }
            });
        }
    }
}
