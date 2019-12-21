using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Reflection;

namespace UnoApp.Shared
{
    public class Startup
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IServiceCollection Services { get; private set; }

        internal static void Init()
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream("UnoApp.appsettings.json"))
            {
                var host = new HostBuilder()
                    .ConfigureHostConfiguration(c =>
                    {
                        c.AddJsonStream(stream);
                    })
                    .ConfigureServices((c, x) => ConfigureServices(c, x))
                    .ConfigureLogging(l => l.AddConsole(abc =>
                    {
                        abc.DisableColors = true;
                    }))
                    .Build();

                ServiceProvider = host.Services;
            }
        }

        private static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            Services = services;

            var world = ctx.Configuration["Hello"];
            var baseUrl = ctx.Configuration["BaseUrl"];

            if (ctx.HostingEnvironment.IsDevelopment())
            {
            }

            services.AddHttpClient("AzureWebSites", client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            })
                .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10),
                }));
        }
    }
}