using Microsoft.EntityFrameworkCore;
using FriendOrganizer.Model;

namespace FriendOrganizer.DataAccess
{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("Filename=FriendsOrganizer.db");
        }

        public DbSet<Friend> Friends { get; set; }
    }
}