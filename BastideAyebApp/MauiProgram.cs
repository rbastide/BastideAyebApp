using Microsoft.Extensions.Logging;
using BastideAyebApp.Services;
using BastideAyebApp.ViewModels;
using BastideAyebApp.Views;

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

        builder.Services.AddTransient<CardDetailViewModel>();
        
        builder.Services.AddTransient<CardDetailPage>();
        
        builder.Services.AddTransient<GamesPage>();
        
        builder.Services.AddTransient<CoinFlipPage>();
        
        builder.Services.AddTransient<NumberGuessPage>();
        
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}