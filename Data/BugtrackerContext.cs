using Microsoft.EntityFrameworkCore;
using bugtracker.Models;

namespace bugtracker.Data
{
    public class BugtrackerContext : DbContext
    {
        public BugtrackerContext(DbContextOptions<BugtrackerContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

    }
}