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
            builder.UseSqlite("Filename=../FriendsOrganizer.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Friend>().HasData(new Friend { Id = 1, FirstName = "Thomas", LastName = "Huber" },
                                             new Friend { Id = 2, FirstName = "Andreas", LastName = "Boehler" },
                                             new Friend { Id = 3, FirstName = "Julia", LastName = "Huber" },
                                             new Friend { Id = 4, FirstName = "Chrissi", LastName = "Egin" });
        }

        public DbSet<Friend> Friends { get; set; }
    }
}