using CommunityToolkit.Maui;
using LogBook.Lib;
using LogBook.LogBookApp.Pages;
using LogBook.LogBookApp.Services;
using LogBook.LogBookCore.Services;
using LogBook.LogBookCore.ViewModels;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace LogBook.LogBookApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddSingleton<ReportViewModel>();
            builder.Services.AddSingleton<ReportPage>();

            string path = FileSystem.AppDataDirectory;
            string filename = "data.xml";
            string fullpath = System.IO.Path.Combine(path, filename);
            System.Diagnostics.Debug.WriteLine("Pfad:");
            System.Diagnostics.Debug.WriteLine(path);

            builder.Services.AddSingleton<IRepository>(new XML_Repository(fullpath));
            builder.Services.AddSingleton<IAlertService, AlertService>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
