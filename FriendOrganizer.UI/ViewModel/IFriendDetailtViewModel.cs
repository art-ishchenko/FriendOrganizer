using FriendOrganizer.Model;
using FriendOrganizer.UI.Wrapper;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public interface IFriendDetailViewModel
    {
        FriendWrapper Friend { get; set; }
        Task LoadAsync(int friendId);
        bool HasChanges { get; }
    }
}