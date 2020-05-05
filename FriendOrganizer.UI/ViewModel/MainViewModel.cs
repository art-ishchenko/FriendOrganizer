using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigationViewModel navigationViewModel, IFriendDetailtViewModel friendDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            FriendDetailViewModel = friendDetailViewModel;
        }

        public INavigationViewModel NavigationViewModel { get; }
        public IFriendDetailtViewModel FriendDetailViewModel { get; }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }
    }
}