using Microsoft.EntityFrameworkCore;
using MyFirstWebApplication.Models;

namespace MyFirstWebApplication.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<ArticleModel> ArticleModels { get; set; }


        public UserContext(DbContextOptions<UserContext> option) : base(option)
        {
            Database.EnsureCreated();
        }
    }
}