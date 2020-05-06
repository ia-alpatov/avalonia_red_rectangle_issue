using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;

namespace DataGridScroll
{
    class Program
    {
        
        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug()
                .UseSkia()
                .UseReactiveUI();
        }
        
        
        private static void AppMain(Application app, string[] args)
        {
            var window = new MainWindow();
            app.Run(window);
        }
        
        public static void Main(string[] args)
        {
            BuildAvaloniaApp().Start(AppMain, args);
        }
        
       
    }
    
}