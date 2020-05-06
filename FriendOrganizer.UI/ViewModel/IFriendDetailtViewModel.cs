using FriendOrganizer.Model;
using FriendOrganizer.UI.Wrapper;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public interface IFriendDetailtViewModel
    {
        FriendWrapper Friend { get; set; }

        Task LoadAsync(int friendId);
    }
}