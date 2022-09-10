using KroyBikroySite.Model;
using Microsoft.EntityFrameworkCore;

namespace KroyBikroySite.Data
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

    }

}
