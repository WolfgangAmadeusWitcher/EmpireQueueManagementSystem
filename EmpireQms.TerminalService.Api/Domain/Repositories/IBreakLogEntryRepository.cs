using EmpireQms.TerminalService.Api.Domain.Models;

namespace EmpireQms.TerminalService.Api.Domain.Repositories
{
    public interface IBreakLogEntryRepository : IRepository<BreakLogEntry>
    {
        void UpdateBreakLogEntry(BreakLogEntry breakLogEntry);
    }
}
