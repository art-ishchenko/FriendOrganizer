using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private readonly IFriendLookupDataService dataService;
        private readonly IEventAggregator eventAggregator;
        private LookupItem _selectedFriend;

        public NavigationViewModel(IFriendLookupDataService dataService, IEventAggregator eventAggregator)
        {
            this.dataService = dataService;
            this.eventAggregator = eventAggregator;
        }

        public ObservableCollection<LookupItem> Friends { get; set; } = new ObservableCollection<LookupItem>();

        public LookupItem SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                _selectedFriend = value;
                //OnPropertyChanged();
                if (_selectedFriend != null)
                {
                    eventAggregator.GetEvent<OpenFriendDetailViewEvent>()
                        .Publish(_selectedFriend.Id);
                }
            }
        }

        public async Task LoadAsync()
        {
            var friends = await dataService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var friend in friends)
                Friends.Add(friend);
        }
    }
}