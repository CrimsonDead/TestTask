using dataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace dataLayer.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                id = 1,
                Email = "mal1@gmail.com",
                UniqNumber = 100582333
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                id = 2,
                Email = "mal2@gmail.com",
                UniqNumber = 140582313
            });
        }
    }
}
