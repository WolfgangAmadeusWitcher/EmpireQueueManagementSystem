using EmpireQms.TicketDispenser.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpireQms.TicketDispenser.Api.Persistence
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {
        }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<EmpireQueue> EmpireQueues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketCategory>().Property(i => i.Id).ValueGeneratedNever();
            modelBuilder.Entity<EmpireQueue>().Property(i => i.Id).ValueGeneratedNever();
        }
    }
}
