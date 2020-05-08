using FriendOrganizer.UI.Event;
using FriendOrganizer.UI.View.Services;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IMessageDialogService messageDialog;
        private readonly IServiceProvider serviceProvider;
        private IFriendDetailViewModel _friendDetailViewModel;

        public MainViewModel(IServiceProvider serviceProvider,
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialog)
        {
            this.serviceProvider = serviceProvider;
            this.eventAggregator = eventAggregator;
            this.messageDialog = messageDialog;
            NavigationViewModel = (INavigationViewModel)serviceProvider.GetService(typeof(INavigationViewModel));
            eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriendDetailView);
        }

        public INavigationViewModel NavigationViewModel { get; }
        public IFriendDetailViewModel FriendDetailViewModel
        {
            get { return _friendDetailViewModel; }
            set
            {
                _friendDetailViewModel = value;
                OnPropertyChanged();
            }
        }
        
        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        private async void OnOpenFriendDetailView(int friendId)
        {
            if(FriendDetailViewModel != null && FriendDetailViewModel.HasChanges)
            {
                if (messageDialog.ShowOkCancelDialog("Do you want to discard changes", "Question") == MessageDialogResult.Cancel)
                    return;
            }
            FriendDetailViewModel = (IFriendDetailViewModel)serviceProvider.GetService(typeof(IFriendDetailViewModel));
            await FriendDetailViewModel.LoadAsync(friendId);
        }


    }
}