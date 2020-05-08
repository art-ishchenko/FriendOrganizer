using FriendOrganizer.Model;
using FriendOrganizer.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;
        private readonly IEventAggregator eventAggregator;

        public NavigationItemViewModel(IEventAggregator eventAggregator, Friend friend)
        {
            Id = friend.Id;
            SetDisplayMember(friend);
            OpenFriendDetailViewCommand = new DelegateCommand(OnOpenFriendDetailsView);
            this.eventAggregator = eventAggregator;
        }

        private void OnOpenFriendDetailsView()
        {
            eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Publish(Id);
        }

        public int Id { get; set; }

        public string DisplayMember
        {
            get
            {
                return _displayMember;
            }
            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenFriendDetailViewCommand { get; }

        private void SetDisplayMember(Friend friend)
        {
            DisplayMember = $"{friend.FirstName} {friend.LastName}";
        }

        internal void Update(Friend friend)
        {
            SetDisplayMember(friend);
        }
    }
}
