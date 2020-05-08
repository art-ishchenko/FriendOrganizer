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
        private readonly IFriendRepository friendRepository;
        private readonly IEventAggregator eventAggregator;

        public NavigationViewModel(IFriendRepository friendRepository, IEventAggregator eventAggregator)
        {
            this.friendRepository = friendRepository;
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<FriendSavedEvent>().Subscribe(OnFriendSaved);
        }

        private void OnFriendSaved(Friend friend)
        {
            NavigationItemViewModel navigationItem = Friends.Single(x => x.Id == friend.Id);
            navigationItem.Update(friend);
        }

        public ObservableCollection<NavigationItemViewModel> Friends { get; set; } = new ObservableCollection<NavigationItemViewModel>();

        public async Task LoadAsync()
        {
            var friends = await friendRepository.GetAll();
            Friends.Clear();
            foreach (var friend in friends)
            {
                Friends.Add(new NavigationItemViewModel(eventAggregator, friend));
            }
        }
    }
}