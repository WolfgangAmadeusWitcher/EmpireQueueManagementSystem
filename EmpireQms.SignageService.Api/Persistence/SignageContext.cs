using EmpireQms.SignageService.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpireQms.SignageService.Api.Persistence
{
    public class SignageContext : DbContext
    {
        public SignageContext(DbContextOptions<SignageContext> options) : base(options)
        {
        }

        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Signage> Signages { get; set; }
        public DbSet<TerminalSignage> TerminalSignages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Terminal>().Property(i => i.Id).ValueGeneratedNever();
            modelBuilder.Entity<Signage>().Property(i => i.Id).ValueGeneratedNever();
            modelBuilder.Entity<TerminalSignage>().ToTable("TerminalSignages");
            modelBuilder.Entity<TerminalSignage>().HasKey(sign => new { sign.TerminalId, sign.SignageId });

            modelBuilder.Entity<TerminalSignage>().HasOne(sign => sign.Terminal)
                .WithMany(terminal => terminal.TerminalSignages).HasForeignKey(trSign => trSign.TerminalId);

            modelBuilder.Entity<TerminalSignage>().HasOne(sign => sign.Signage).
                WithMany(signage => signage.TerminalSignages).HasForeignKey(trSign => trSign.SignageId);
        }
    }
}
