using EmpireQms.Monitoring.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpireQms.Monitoring.Api.Persistence
{
    public class MonitoringContext : DbContext
    {
        public MonitoringContext(DbContextOptions<MonitoringContext> options) : base(options)
        {
        }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<BreakLogEntry> BreakLogEntries { get; set; }
        public DbSet<EmpireQueue> EmpireQueues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Terminal>().Property(t => t.Id).ValueGeneratedNever();
            modelBuilder.Entity<Terminal>().Ignore(t => t.BreakLogEntries);
            modelBuilder.Entity<BreakLogEntry>().ToTable("BreakLogEntries");
            modelBuilder.Entity<BreakLogEntry>().Property(i => i.Id).ValueGeneratedNever();
            modelBuilder.Entity<EmpireQueue>().Property(i => i.Id).ValueGeneratedNever();
        }
    }
}
