using GestionITM.AppMovil.Services;
using GestionITM.AppMovil.ViewModels;
using GestionITM.AppMovil.Views;
using Microsoft.Extensions.Logging;

namespace GestionITM.AppMovil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMaui()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // URL base según plataforma — Android emulador usa 10.0.2.2 para localhost
#if ANDROID
            var baseUrl = "http://10.0.2.2:8080/";
#else
            var baseUrl = "http://localhost:8080/";
#endif

            builder.Services.AddTransient<AuthDelegatingHandler>();
            builder.Services.AddHttpClient<ApiService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            }).AddHttpMessageHandler<AuthDelegatingHandler>();

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<CatalogoViewModel>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<CatalogoPage>();

            return builder.Build();
        }
    }
}
