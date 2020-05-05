using System.IO;
using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using FriendOrganizer.UI.ViewModel;
using FriendOrganizer.UI.Data;
using Microsoft.Extensions.Configuration;
using FriendOrganizer.DataAccess;

namespace FriendOrganizer.UI
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; set; }
        public IConfiguration Configuration { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            // Configuration = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //     .Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<AppDbContext>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<MainWindow>();
            services.AddTransient<IFriendDataService, FriendDataService>();
            services.AddTransient<INavigationViewModel, NavigationViewModel>();
            services.AddTransient<IFriendLookupDataService, LookupDataService>();
        }
    }
}
