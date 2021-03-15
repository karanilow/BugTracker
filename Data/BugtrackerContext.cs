using Microsoft.EntityFrameworkCore;
using bugtracker.Models;

namespace bugtracker.Data
{
    public class BugtrackerContext : DbContext
    {
        public BugtrackerContext(DbContextOptions<BugtrackerContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketHistory> TicketHistories { get; set; }
        public DbSet<TicketInfo> TicketInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<TicketHistory>().ToTable("TicketHistory");
            modelBuilder.Entity<TicketInfo>().ToTable("TicketInfo");
        }

    }
}