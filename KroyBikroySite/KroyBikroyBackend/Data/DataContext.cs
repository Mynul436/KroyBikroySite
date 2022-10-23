using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KroyBikroyBackend.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<User> users { get; set; }
    }
}
