using EmpireQms.TerminalService.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpireQms.TerminalService.Api.Persistence
{
    public class TerminalContext : DbContext
    {
        public TerminalContext(DbContextOptions<TerminalContext> options) : base(options)
        {
        }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<BreakLogEntry> BreakLogEntries { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<TerminalCategory> TerminalCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Terminal>().Property(i => i.Id).ValueGeneratedNever();
            modelBuilder.Entity<Terminal>().HasMany(x => x.BreakLogEntries);
            modelBuilder.Entity<TicketCategory>().Property(i => i.Id).ValueGeneratedNever();
            modelBuilder.Entity<TerminalCategory>().ToTable("TerminalCategories");
            modelBuilder.Entity<TerminalCategory>()
            .HasKey(t => new { t.TerminalId, t.TicketCategoryId });
            modelBuilder.Entity<TicketCategory>().ToTable("TicketCategories");
        }
    }
}
