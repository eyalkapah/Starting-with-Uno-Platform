using Microsoft.Extensions.DependencyInjection;
using System;

//using UnoApp.Shared.Extensions;

namespace UnoApp.Shared.ViewModels
{
    public class IoC
    {
        private static IServiceProvider _provider;
        private static IServiceCollection _services => Startup.Services;

        public static void RegisterContainer()
        {
            RegisterViewModels();

            _provider = _services.BuildServiceProvider();
        }

        private static void RegisterViewModels()
        {
            RegisterViewModel<MainPageViewModel>();
        }

        public static T Resolve<T>() where T : class
        {
            return _provider.GetService<T>();
        }

        public static Type Resolve(Type type)
        {
            return (Type)_provider.GetService(type);
        }

        private static void RegisterViewModel<T>() where T : class
        {
            _services.AddScoped<T>();
        }
    }
}