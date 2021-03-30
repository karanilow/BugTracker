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
        public DbSet<ProjectAssignment> ProjectAssignments { get; set; }
        public DbSet<TicketAssignment> TicketAssignments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<TicketHistory>().ToTable("TicketHistory");
            modelBuilder.Entity<TicketAssignment>().ToTable("TicketAssignment");
            modelBuilder.Entity<ProjectAssignment>().ToTable("ProjectAssignment");

            // configure Primary Key
            modelBuilder.Entity<TicketAssignment>()
                .HasKey(t => new { t.TicketID, t.UserID });
            // configure Primary Key
            modelBuilder.Entity<ProjectAssignment>()
                .HasKey(p => new { p.ProjectID, p.UserID });


        }

    }
}