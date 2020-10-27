using EmpireQms.Monitoring.Api.Domain.Models;

namespace EmpireQms.Monitoring.Api.Domain.Repositories
{
    public interface IBreakLogEntryRepository : IRepository<BreakLogEntry>
    {
        void UpdateBreakLogEntry(BreakLogEntry breakLogEntry);
    }
}
