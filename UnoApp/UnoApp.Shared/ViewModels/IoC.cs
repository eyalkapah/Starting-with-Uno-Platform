using Microsoft.Extensions.DependencyInjection;
using System;

//using UnoApp.Shared.Extensions;

namespace UnoApp.Shared.ViewModels
{
    public static class IoC
    {
        private static IServiceProvider _provider;

        public static void SetServiceProvider(IServiceProvider provider)
        {
            _provider = provider;
        }

        public static T Resolve<T>() where T : class
        {
            return _provider.GetService<T>();
        }

        public static Type Resolve(Type type)
        {
            return (Type)_provider.GetService(type);
        }
    }
}