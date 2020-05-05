using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;
        public NavigationItemViewModel(Friend friend)
        {
            Id = friend.Id;
            SetDisplayMember(friend);
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
