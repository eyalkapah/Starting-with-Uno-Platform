using Microsoft.Extensions.DependencyInjection;
using UnoApp.Shared.Services;
using UnoApp.Shared.ViewModels;

namespace UnoApp.Shared.Configurations
{
    public static class ServicesConfigurations
    {
        public static void RegisterViewModels(this IServiceCollection services)
        {
            services.AddScoped<MainPageViewModel>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<INavigationService, NavigationService>();
        }
    }
}