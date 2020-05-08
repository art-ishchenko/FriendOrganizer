using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using FriendOrganizer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private readonly IFriendRepository friendRepository;
        private readonly IEventAggregator eventAggregator;
        private FriendWrapper _friend;
        private bool _hasChanges;

        public FriendDetailViewModel(IFriendRepository friendRepository,
            IEventAggregator eventAggregator)
        {
            this.friendRepository = friendRepository;
            this.eventAggregator = eventAggregator;
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private async void OnOpenFriendDetailView(int friendId)
        {
            await LoadAsync(friendId);
        }

        public async Task LoadAsync(int friendId)
        {
            var friend = await friendRepository.GetByIdAsync(friendId);
            Friend = new FriendWrapper(friend);
            Friend.PropertyChanged += (s, e) =>
            {
                HasChanges = friendRepository.HasChanges();
                if (e.PropertyName == nameof(Friend.HasErrors))
                    RaiseCanExecuteChanged();
            };
            RaiseCanExecuteChanged();
        }


        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnPropertyChanged();
                    RaiseCanExecuteChanged();
                }
            }
        }

        public FriendWrapper Friend
        {
            get { return _friend; }
            set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        private void RaiseCanExecuteChanged()
        {
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        private async void OnSaveExecute()
        {
            await friendRepository.SaveChangesAsync();
            HasChanges = friendRepository.HasChanges();
            eventAggregator.GetEvent<FriendSavedEvent>().Publish(Friend.Model);
        }

        private bool OnSaveCanExecute()
        {
            var isValid = !(Friend == null || Friend.HasErrors);
            return isValid && HasChanges;
        }
    }
}
