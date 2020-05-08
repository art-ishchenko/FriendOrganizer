using FriendOrganizer.DataAccess;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.View.Services;
using FriendOrganizer.UI.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
using System;
using System.Windows;

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
            services.AddTransient<AppDbContext>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<MainWindow>();
            services.AddTransient<IMessageDialogService, MessageDialogService>();
            services.AddTransient<IFriendRepository, FriendRepository>();
            services.AddTransient<INavigationViewModel, NavigationViewModel>();
            services.AddTransient<IFriendDetailViewModel, FriendDetailViewModel>();
            services.AddSingleton<IEventAggregator, EventAggregator>();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Oops, something failed :(");
        }
    }
}
