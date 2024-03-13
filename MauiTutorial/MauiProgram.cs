using MauiTutorial.ViewModel;
using Microsoft.Extensions.Logging;

namespace MauiTutorial
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            // İnternet baglantısını kontrol Eder!!
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

            // Buraya EkledigimizTüm Sayfaları tanımlıyorz!
            // Burası Global 1 Kere Tanımlanacak == AddSingleton
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            // Her sayfa tanımlandıgında ==> AddTransient Eklenecek!
            builder.Services.AddTransient<DetailPage>();
            builder.Services.AddTransient<DetailViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
