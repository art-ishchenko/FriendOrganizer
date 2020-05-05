using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private readonly IFriendDataService dataService;
        private readonly IEventAggregator eventAggregator;
        private NavigationItemViewModel _selectedFriend;

        public NavigationViewModel(IFriendDataService dataService, IEventAggregator eventAggregator)
        {
            this.dataService = dataService;
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<FriendSavedEvent>().Subscribe(OnFriendSaved);
        }

        private void OnFriendSaved(Friend friend)
        {
            NavigationItemViewModel navigationItem = Friends.Single(x => x.Id == friend.Id);
            navigationItem.Update(friend);
        }

        public ObservableCollection<NavigationItemViewModel> Friends { get; set; } = new ObservableCollection<NavigationItemViewModel>();

        public NavigationItemViewModel SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                _selectedFriend = value;
                OnPropertyChanged();
                if (_selectedFriend != null)
                {
                    eventAggregator.GetEvent<OpenFriendDetailViewEvent>()
                        .Publish(_selectedFriend.Id);
                }
            }
        }

        public async Task LoadAsync()
        {
            var friends = await dataService.GetAll();
            Friends.Clear();
            foreach (var friend in friends)
            {
                Friends.Add(new NavigationItemViewModel(friend));
            }
        }
    }
}