namespace ShareInvest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            if (MauiApp.CreateBuilder() is MauiAppBuilder builder)
            {
                builder
                    .UseMauiApp<App>()
                    .ConfigureFonts(o =>
                    {
                        o.AddFont("Metropolis-Black.otf", "Metropolis Black");
                        o.AddFont("Metropolis-Light.otf", "Metropolis Light");
                        o.AddFont("Metropolis-Medium.otf", "Metropolis Medium");
                        o.AddFont("Metropolis-Regular.otf", "Metropolis Regular");
                        o.AddFont("MaterialIcons-Regular.ttf", "Material Icons");
                        o.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                        o.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    });
                return builder.Build();
            }
            return null;
        }
    }
}