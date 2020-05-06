using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailtViewModel : ViewModelBase, IFriendDetailtViewModel
    {
        private readonly IFriendDataService dataService;
        private readonly IEventAggregator eventAggregator;
        private Friend _friend;


        public FriendDetailtViewModel(IFriendDataService dataService, IEventAggregator eventAggregator)
        {
            this.dataService = dataService;
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<OpenFriendDetailViewEvent>()
                .Subscribe(OnOpenFriendDetailView);
        }

        private async void OnOpenFriendDetailView(int friendId)
        {
            await LoadAsync(friendId);
        }

        public async Task LoadAsync(int friendId)
        {
            Friend = await dataService.GetByIdAsync(friendId);
        }


        public Friend Friend
        {
            get { return _friend; }
            set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand => new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        private async void OnSaveExecute()
        {
            await dataService.Save(Friend);
            eventAggregator.GetEvent<FriendSavedEvent>().Publish(Friend);
        }

        private bool OnSaveCanExecute()
        {
            return true;
        }
    }
}
