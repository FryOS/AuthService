using Microsoft.EntityFrameworkCore;


namespace AuthService.Models
{
    public class UserContext : DbContext

    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
    }
}
