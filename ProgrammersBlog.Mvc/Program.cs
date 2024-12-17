using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;


using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data;
using Microsoft.Extensions.DependencyInjection;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;



namespace ProgrammersBlog.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.Sources.Clear();
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                  .UseUrls("http://localhost:5000", "http://192.168.1.13:5000"); // IP adresi ve port numarasý UseUrls("http://localhost:5000", "http://192.168.1.16:5000")
                //.UseUrls("http://localhost:5000", "http://192.168.1.104:5000"); // IP adresi ve port numarasý UseUrls("http://localhost:5000", "http://192.168.1.16:5000")
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                })
                .UseNLog();
    }
}

