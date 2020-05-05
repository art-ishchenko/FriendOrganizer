using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private readonly AppDbContext ctx;

        public FriendDataService(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<Friend> GetByIdAsync(int id)
        {
            return await ctx.Friends.AsNoTracking().SingleAsync(f => f.Id == id);
        }
    }

}