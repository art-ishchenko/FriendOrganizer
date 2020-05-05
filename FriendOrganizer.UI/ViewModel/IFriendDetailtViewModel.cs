using FriendOrganizer.Model;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public interface IFriendDetailtViewModel
    {
        Friend Friend { get; set; }

        Task LoadAsync(int friendId);
    }
}