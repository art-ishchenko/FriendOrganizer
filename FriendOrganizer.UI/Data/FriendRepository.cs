using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class FriendRepository : IFriendRepository
    {
        private readonly AppDbContext ctx;

        public FriendRepository(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IEnumerable<Friend>> GetAll()
        {
            return await ctx.Friends
                .ToListAsync();
        }

        public async Task<Friend> GetByIdAsync(int id)
        {
            return await ctx.Friends
                .SingleAsync(f => f.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await ctx.SaveChangesAsync();
        }

        public bool HasChanges() {
            return ctx.ChangeTracker.HasChanges();
        }
    }

}