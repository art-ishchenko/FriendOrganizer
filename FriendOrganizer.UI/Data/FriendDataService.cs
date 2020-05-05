using System.Collections.Generic;
using System.Threading.Tasks;
using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private readonly AppDbContext ctx;

        public FriendDataService(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IEnumerable<Friend>> GetAllAsync()
        {
            return await ctx.Friends.ToListAsync();
        }
    }

}