using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using SchoolMachine.DbConnectionManagement;
using System;

namespace SchoolMachine.DbGeneratorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            Environment.Exit(0);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                    KeyVaultConnectionManager.ConfigureSchoolMachineConfiguration(context, config)
                )
                .UseStartup<Startup>();
    }
}