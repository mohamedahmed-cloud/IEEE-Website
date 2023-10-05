using IEEEWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace IEEEWebsite.Context
{
    public class IEEEContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Warning> Warnings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MOHAMED\\SQLEXPRESS;database=IEEE;trusted_Connection=true;Encrypt=false");
        }
       /* add this to increase time of execute the query*/
        public void ApplicationDbContext()
        {
            Database.SetCommandTimeout(150000);
        }


    }
}
