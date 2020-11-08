using EmpireQms.AdminModule.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpireQms.AdminModule.Api.Persistence
{
    public class SettingsContext : DbContext
    {
        public SettingsContext(DbContextOptions<SettingsContext> options) : base(options)
        {
        }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Signage> Signages { get; set; }
        public DbSet<TerminalCategory> TerminalCategories { get; set; }
        public DbSet<TerminalSignage> TerminalSignages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Terminal>().Ignore(t => t.Status);

            modelBuilder.Entity<TerminalSignage>().ToTable("TerminalSignages");
            modelBuilder.Entity<TerminalSignage>().HasKey(sign => new { sign.TerminalId, sign.SignageId });

            modelBuilder.Entity<TerminalSignage>().HasOne(sign => sign.Terminal)
                .WithMany(terminal => terminal.TerminalSignages).HasForeignKey(trSign => trSign.TerminalId);

            modelBuilder.Entity<TerminalSignage>().HasOne(sign => sign.Signage).
                WithMany(signage => signage.TerminalSignages).HasForeignKey(trSign => trSign.SignageId);

            modelBuilder.Entity<TerminalCategory>().ToTable("TerminalCategories");
            modelBuilder.Entity<TerminalCategory>()
            .HasKey(t => new { t.TerminalId, t.TicketCategoryId });

            modelBuilder.Entity<TerminalCategory>()
            .HasOne(tc => tc.Terminal)
            .WithMany(terminal => terminal.TerminalCategories).HasForeignKey(tc => tc.TerminalId);

            modelBuilder.Entity<TerminalCategory>()
            .HasOne(tc => tc.TicketCategory)
            .WithMany(ticketCategory => ticketCategory.TerminalCategories).HasForeignKey(tc => tc.TicketCategoryId);

            modelBuilder.Entity<TicketCategory>().HasData(
                new TicketCategory
                {
                    Id = 1,
                    Name = @"Gişe İşlemleri",
                    Description = @"Gişe işlemleri yapmak",
                    FirstTicketNumber = 100,
                    LastTicketNumber = 200,
                    PriorityCoefficient = 1
                },
                new TicketCategory
                {
                    Id = 2,
                    Name = @"Bireysel Hizmetler",
                    Description = @"Bireysel Bankacılık hizmetlerimizden faydalanmak",
                    FirstTicketNumber = 300,
                    LastTicketNumber = 450,
                    PriorityCoefficient = 3
                },
                new TicketCategory
                {
                    Id = 3,
                    Name = @"Ticari İşlemler",
                    Description = @"Kurumsal Bankacılık hizmetlerimizden faydalanmak",
                    FirstTicketNumber = 450,
                    LastTicketNumber = 750,
                    PriorityCoefficient = 5
                }
            );
        }
    }
}
