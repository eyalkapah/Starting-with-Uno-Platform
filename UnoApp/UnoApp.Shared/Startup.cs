using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using UnoApp.Shared.Configurations;
using UnoApp.Shared.ViewModels;

namespace UnoApp.Shared
{
    public class Startup
    {
        public static IConfigurationRoot Configuration { get; private set; }

        internal static void Init()
        {
            //var host = new HostBuilder()
            //.ConfigureHostConfiguration(c =>
            //{
            //    c.AddJsonStream(stream);
            //})
            //.ConfigureServices((c, x) => ConfigureServices(c, x))
            //.ConfigureLogging(l => l.AddConsole(abc =>
            //{
            //    abc.DisableColors = true;
            //}))
            //.Build();
            //        }

            //        var assembly = Assembly.GetExecutingAssembly();

            //        var resourceName = assembly.GetManifestResourceNames()
            //            .FirstOrDefault(f => f.Contains("appsettings.json"));

            //            if (!string.IsNullOrEmpty(resourceName))
            //            {
            //                using (var s = assembly.GetManifestResourceStream(resourceName))
            //                {
            //                    //var content = s.ReadToEnd();

            //                    var host = new HostBuilder()
            //                    //.ConfigureHostConfiguration(c =>
            //                    //{
            //                    //    //c.AddJsonStream(s);
            //                    //})
            //                    .ConfigureServices((c, x) => ConfigureServices(c, x))
            //                    //.ConfigureLogging(l => l.AddConsole(abc =>
            //                    //{
            //                    //    abc.DisableColors = true;
            //                    //}))
            //                    .Build();
            //    }
            //}
        }

        internal static void ConfigureServices(ServiceCollection services)
        {
            var resourcePrefix = "";

#if __IOS__
            resourcePrefix = "UnoApp.iOS.";
#endif
#if __ANDROID__
            resourcePrefix = "UnoApp.Droid.";
#endif
#if WINDOWS_UWP
            resourcePrefix = "UnoApp.";
#endif

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Startup)).Assembly;
            Stream stream = assembly.GetManifestResourceStream
                (resourcePrefix + "appsettings.json");

            var conf = new ConfigurationBuilder()
                .AddJsonStream(stream);

            Configuration = conf.Build();

            services.AddSingleton(typeof(IConfiguration), Configuration);

            services.RegisterViewModels();
            services.RegisterServices();

            //var world = ctx.Configuration["Hello"];
            //var baseUrl = ctx.Configuration["BaseUrl"];

            //if (ctx.HostingEnvironment.IsDevelopment())
            //{
            //}

            //            var resourcePrefix = "";
            //#if __IOS__
            //resourcePrefix = "UnoApp.iOS.";
            //#endif
            //#if __ANDROID__
            //resourcePrefix = "UnoApp.Droid.";
            //#endif
            //#if WINDOWS_UWP
            //            resourcePrefix = "UnoApp.UWP.";
            //#endif

            //            Debug.WriteLine("Using this resource prefix: " + resourcePrefix);
            //            // note that the prefix includes the trailing period '.' that is required
            //            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Startup)).Assembly;
            //            Stream stream = assembly.GetManifestResourceStream
            //                (resourcePrefix + "appsettings.json");

            //            var conf = new ConfigurationBuilder()
            //                .AddJsonStream(stream);

            //            var configuration = conf.Build();

            services.AddHttpClient("AzureWebSites", client =>
            {
                client.BaseAddress = new Uri("http: //10.0.2.2:5000/");
            })
                .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10),
                }));

            IoC.SetServiceProvider(services.BuildServiceProvider());
        }

        private static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            services.RegisterViewModels();
            services.RegisterServices();

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

            IoC.SetServiceProvider(services.BuildServiceProvider());
        }
    }
}