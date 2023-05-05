﻿using Microsoft.Extensions.Logging;
using Mobile.KMT.Services.Implementations;
using Mobile.KMT.Services.Interfaces;
using Mobile.KMT.ViewModels;
using Mobile.KMT.Views;

namespace Mobile.KMT;

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

        builder.Services.AddSingleton<BaseViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<LoginPageViewModel>();

        builder.Services.AddSingleton(typeof(ILoggerService), typeof(LoggerService));

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
