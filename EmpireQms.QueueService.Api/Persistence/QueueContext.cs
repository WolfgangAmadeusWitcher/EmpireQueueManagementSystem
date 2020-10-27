using EmpireQms.QueueService.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpireQms.QueueService.Api.Persistence
{
    public class QueueContext : DbContext
    {
        public QueueContext(DbContextOptions<QueueContext> options) : base(options)
        {
        }
        public DbSet<EmpireQueue> EmpireQueues { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<TerminalCategory> TerminalCategories { get; set; }
        public DbSet<TerminalTicket> TerminalTickets { get; set; }
        public DbSet<Terminal> Terminals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Terminal>().Property(i => i.Id).ValueGeneratedNever();
            modelBuilder.Entity<Ticket>().Property(i => i.Id).ValueGeneratedNever();
            modelBuilder.Entity<TicketCategory>().Property(i => i.Id).ValueGeneratedNever();
            modelBuilder.Entity<TerminalCategory>().ToTable("TerminalCategories");
            modelBuilder.Entity<TerminalCategory>()
            .HasKey(t => new { t.TerminalId, t.TicketCategoryId });
            modelBuilder.Entity<TicketCategory>().ToTable("TicketCategories");
            modelBuilder.Entity<TerminalTicket>().HasKey(t => new { t.TerminalId, t.TicketId });
        }
    }
}
