using EmpireQms.Printer.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpireQms.PrintService.Api.Persistence
{
    public class PrintContext:DbContext
    {
        public PrintContext(DbContextOptions<PrintContext> options):base(options)
        {

        }

        public DbSet<PrintTemplate> PrintTemplates { get; set; }

    }
}
