using System.Windows;
using FriendOrganizer.UI.ViewModel;

namespace FriendOrganizer.UI
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel mainViewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            this.mainViewModel = mainViewModel;
            DataContext = mainViewModel;
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            mainViewModel.Load();
        }
    }
}
