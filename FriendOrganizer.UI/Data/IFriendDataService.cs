using System.Collections.Generic;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data
{
    public interface IFriendDataService
    {
        Task<IEnumerable<Friend>> GetAllAsync();
    }

}