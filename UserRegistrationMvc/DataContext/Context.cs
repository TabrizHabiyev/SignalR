using Microsoft.EntityFrameworkCore;
using UserRegistrationMvc.Models;

namespace UserRegistrationMvc.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1 , Name = "Admin"},
                new Role { Id = 2 , Name = "Medarotor"},
                new Role { Id = 3 , Name = "Mmber"}
                );
        }
    }
}
