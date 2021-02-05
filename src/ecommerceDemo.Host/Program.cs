using System;
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
            var configuration = InitialHelper.GetConfiguration(Directory.GetCurrentDirectory(), Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));

            Log.Logger = InitialHelper.CreateELKLogger(new ELKLoggerSettings
            {
                AppName = configuration["AppName"],
                ElasticsearchURL = configuration["ElasticsearchURL"]
            });

            var host = CreateHostBuilder(args, configuration).Build();

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
    }
}
