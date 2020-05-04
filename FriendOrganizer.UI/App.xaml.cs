using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using FriendOrganizer.UI.ViewModel;
using FriendOrganizer.UI.Data;

namespace FriendOrganizer.UI
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MainViewModel>();
            services.AddTransient<MainWindow>();
            services.AddTransient<IFriendDataService, FriendDataService>();
        }
    }
}
