using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using MudBlazor.Services;
using TraceabilityNutRunner_CYLHead;
using Microsoft.Extensions.DependencyInjection;
using TraceabilityNutRunner_CYLHead.Services;

namespace TraceabilityNutRunner_CYLHead
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
                


            // Load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(FileSystem.AppDataDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            builder.Configuration.AddConfiguration(configuration);

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Services.AddMudServices();
            // Manually add HttpClient
            builder.Services.AddSingleton<HttpClient>(sp => new HttpClient());
            builder.Services.AddSingleton<ApiService>();
            builder.Services.AddHttpClient(); // Adds HttpClient for making API requests
                                              // Register HttpClient to be used for API calls
            
            builder.Services.AddSingleton<TighteningResultService>(); // Register the service to handle sending data


            //builder.Services.AddSingleton<FtpService>(sp =>
            //    new FtpService("192.168.137.248", "Intouch", "1111"));

            

            //builder.Services.AddSingleton<FtpService>();
            builder.Services.AddSingleton<DataFromCsv>();
#endif

            return builder.Build();
        }
    }
}
