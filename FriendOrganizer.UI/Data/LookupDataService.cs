using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;

namespace FriendOrganizer.UI.Data
{
    public class LookupDataService : IFriendLookupDataService
    {
        private readonly AppDbContext context;

        public LookupDataService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<LookupItem>> GetFriendLookupAsync()
        {
            return await context.Friends.AsNoTracking()
            .Select(f => new LookupItem
            {
                Id = f.Id,
                DisplayMember = f.FirstName + " " + f.LastName
            })
            .ToListAsync();
        }
    }
}