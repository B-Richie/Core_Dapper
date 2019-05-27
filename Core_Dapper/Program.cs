using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Core_Dapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            var nlogLogger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            var host = CreateWebHostBuilder(args).Build();
            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            nlogLogger.Debug("inside main method");
            logger.LogInformation("main method inside program");

            host.Run();


            //try
            //{
            //    var host = CreateWebHostBuilder(args).Build();
            //    var logger = host.Services.GetRequiredService<ILogger<Program>>();
            //    nlogLogger.Debug("inside main method");
            //    logger.LogInformation("main method inside program");

            //    host.Run();
            //}
            //catch(Exception ex)
            //{
            //    nlogLogger.Error(ex, "Main method encountered an exception");
            //}
            //finally
            //{
            //    NLog.LogManager.Shutdown();
            //}

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Trace);
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
                logging.AddEventSourceLogger();
            })
            .UseNLog()
            .UseStartup<Startup>();
    }
}
