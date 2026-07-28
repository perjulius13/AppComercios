using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;



namespace AppComercios
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                  .UseMauiMaps()
                  .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureMauiHandlers(handlers =>
                {
#if ANDROID
                    handlers.AddHandler<Microsoft.Maui.Controls.Maps.Map, AppComercios.Platforms.Android.CustomMapHandler>();
#elif IOS
            handlers.AddHandler<Microsoft.Maui.Controls.Maps.Map, AppComercios.Platforms.iOS.CustomMapHandler>();
#endif
                });
                


#if DEBUG
    		builder.Logging.AddDebug();
#endif





            return builder.Build();
        }
    }
}
