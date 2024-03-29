﻿using System;
using System.IO;
using Makc2021.Layer1.Common.Config.NLog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog.Web;

namespace Makc2021.Layer6.Sql.WebGrpcServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLog.LogManager.LogFactory.LoadConfigFromXmlFile(
                Path.Combine(AppContext.BaseDirectory, "ConfigFiles", "nlog.config"),
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                ).GetCurrentClassLogger();

            try
            {
                logger.Debug($"init main: {Environment.MachineName}");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");

                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseNLog().UseStartup<Startup>();
                });
    }
}
