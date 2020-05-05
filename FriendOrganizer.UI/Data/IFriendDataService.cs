using FriendOrganizer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public interface IFriendDataService
    {
        Task<IEnumerable<Friend>> GetAll();
        Task<Friend> GetByIdAsync(int id);
        Task Save(Friend friend);
    }

}