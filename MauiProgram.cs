using CommunityToolkit.Maui;
using LaceUpTesting.Services.AppEnvironmentService;
using LaceUpTesting.Services.CatalogService;
using LaceUpTesting.Services.Dialog;
using LaceUpTesting.Services.Navigation;
using LaceUpTesting.Services.RequestProvider;
using LaceUpTesting.Storage;
using LaceUpTesting.Storage.Cart;
using LaceUpTesting.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace LaceUpTesting
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterAppServices()
                .RegisterViews()
                .RegisterViewModels();

#if DEBUG
    		builder.Logging.AddDebug();
#endif
          
            return builder.Build();
        }

        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<INavigationService, MauiNavigationService>();
            mauiAppBuilder.Services.AddSingleton<IDialogService, DialogService>();
            mauiAppBuilder.Services.AddSingleton<IRequestProvider, RequestProvider>();
            mauiAppBuilder.Services.AddSingleton<DbSource>();
            mauiAppBuilder.Services.AddSingleton<CartDbSource>();
            mauiAppBuilder.Services.AddSingleton<IAppEnvironmentService, AppEnvironmentService>(
            serviceProvider =>   
            
          {
              var requestProvider = serviceProvider.GetService<IRequestProvider>();



              var appEnvironmentService =
                  new AppEnvironmentService(new CatalogService(requestProvider!));


              appEnvironmentService.UpdateDependencies();
              return appEnvironmentService;
          });

#if DEBUG
            mauiAppBuilder.Logging.AddDebug();
#endif

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {

            mauiAppBuilder.Services.AddTransient<CartViewModel>();
            mauiAppBuilder.Services.AddTransient<ProductCatalogViewModel>();
            mauiAppBuilder.Services.AddTransient<ProductDetailsViewModel>();


            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {

            mauiAppBuilder.Services.AddTransient<ProductCatalogView>();
            mauiAppBuilder.Services.AddTransient<ProductDetailsView>();
            mauiAppBuilder.Services.AddTransient<CartCheckoutView>();


            return mauiAppBuilder;
        }
    }
}
