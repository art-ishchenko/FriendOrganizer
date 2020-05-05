using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Friend>> GetAll()
        {
            return await ctx.Friends.ToListAsync();
        }

        public async Task<Friend> GetByIdAsync(int id)
        {
            return await ctx.Friends.AsNoTracking().SingleAsync(f => f.Id == id);
        }

        public async Task Save(Friend friend)
        {
            ctx.Attach(friend);
            ctx.Entry(friend).State = EntityState.Modified;
            await ctx.SaveChangesAsync();
        }
    }

}