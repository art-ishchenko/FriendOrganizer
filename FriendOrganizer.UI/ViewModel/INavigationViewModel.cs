using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.ViewModel
{
    public interface INavigationViewModel
    {
        ObservableCollection<NavigationItemViewModel> Friends { get; set; }
        Task LoadAsync();
    }
}