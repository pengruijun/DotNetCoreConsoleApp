using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DotNetCoreConsoleApp.Service;
using System.IO;
using System.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DotNetCoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddSingleton<App>();
            services.AddSingleton<IPrintService, PrintService>();

            //configuration
            var appsettingsConfig = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            services.AddSingleton<IConfiguration>(appsettingsConfig);

            //logging
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("app.log")
                .CreateLogger();

            //services.AddLogging(loggingBuilder => loggingBuilder.AddConsole());
            //services.AddLogging(loggingBuilder => loggingBuilder.AddDebug());
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());

            var serviceProvider = services.BuildServiceProvider();
            var app = serviceProvider.GetService<App>();
            //var printService = serviceProvider.GetService<IPrintService>();

           


            Console.WriteLine(app.PrintApp());
            //Console.WriteLine(printService.Print());
            //Console.WriteLine(appsettingsConfig["configPrint"]);
        }
    }
}
