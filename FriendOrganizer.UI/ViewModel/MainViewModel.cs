using System.ComponentModel;
using System.Collections.ObjectModel;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IFriendDataService friendDataService;
        private Friend _selectedFriend;

        public MainViewModel(IFriendDataService friendDataService)
        {
            this.friendDataService = friendDataService;
        }
        public ObservableCollection<Friend> Friends { get; set; } = new ObservableCollection<Friend>();
        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                _selectedFriend = value;
                OnPropertyChanged();
            }
        }

        public void Load()
        {
            var friends = friendDataService.GetAll();
            Friends.Clear();
            foreach (var friend in friends)
            {
                Friends.Add(friend);
            }
        }



    }
}