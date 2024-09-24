using MusicApp.Context;
using MusicApp.Infrastructure;
using MusicApp.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MusicApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AppServiceProvider.Initialize();

            var dbContextInit = (MusicDbContext)(AppServiceProvider.ServiceProvider.GetService(typeof(MusicDbContext)));

            var window = (LoginView)(AppServiceProvider.ServiceProvider.GetService(typeof(LoginView)));
            window.ShowDialog();
        }
    }

}
