using Microsoft.Extensions.Logging;
using BastideAyebApp.Services;
using BastideAyebApp.ViewModels;

namespace BastideAyebApp;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        builder.Services.AddSingleton<CardService>();
        
        builder.Services.AddTransient<DrawViewModel>();
        
        builder.Services.AddTransient<DrawPage>();
        

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}