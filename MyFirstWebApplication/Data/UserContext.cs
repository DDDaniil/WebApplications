using Microsoft.EntityFrameworkCore;
using MyFirstWebApplication.Models;

namespace MyFirstWebApplication.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> option) : base(option)
        {
            Database.EnsureCreated();
        }
    }
}