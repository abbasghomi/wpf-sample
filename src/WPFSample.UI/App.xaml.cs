using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WPFSample.Infrastructure.Interfaces;
using WPFSample.Infrastructure.Services;

namespace WPFSample.UI
{
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                        new ServiceCollection()
                        .AddSingleton<MainWindow>()
                        .AddSingleton<ICsvHelper, CsvHelper>()
                        .BuildServiceProvider());
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = Ioc.Default.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
