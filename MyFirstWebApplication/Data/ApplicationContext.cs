using Microsoft.EntityFrameworkCore;
using MyFirstWebApplication.Models;

namespace MyFirstWebApplication.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option)
        {
            //Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ArticleModel> ArticleModels { get; set; }
        


    }
}