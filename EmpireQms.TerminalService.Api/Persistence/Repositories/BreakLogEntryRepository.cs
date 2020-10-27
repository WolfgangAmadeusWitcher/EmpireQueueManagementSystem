using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.TerminalService.Api.Domain.Repositories;

namespace EmpireQms.TerminalService.Api.Persistence.Repositories
{
    public class BreakLogEntryRepository : Repository<BreakLogEntry>, IBreakLogEntryRepository
    {
        private TerminalContext _terminalContext;

        public BreakLogEntryRepository(TerminalContext context) : base(context, context.BreakLogEntries)
        {
            _terminalContext = context;
        }
        public void UpdateBreakLogEntry(BreakLogEntry breakLogEntry)
        {
            _terminalContext.Entry(breakLogEntry).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _terminalContext.SaveChanges();
        }
    }
}
