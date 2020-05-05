using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : INavigationViewModel
    {
        private readonly IFriendLookupDataService dataService;

        public NavigationViewModel(IFriendLookupDataService dataService)
        {
            this.dataService = dataService;
        }

        public ObservableCollection<LookupItem> Friends { get; set; } = new ObservableCollection<LookupItem>();

        public async Task LoadAsync()
        {
            var friends = await dataService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var friend in friends)
                Friends.Add(friend);
        }
    }
}