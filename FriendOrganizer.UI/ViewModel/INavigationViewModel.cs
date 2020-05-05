using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.ViewModel
{
    public interface INavigationViewModel
    {
        ObservableCollection<LookupItem> Friends { get; set; }
        Task LoadAsync();
    }
}