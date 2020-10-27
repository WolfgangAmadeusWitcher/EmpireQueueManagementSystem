using EmpireQms.Monitoring.Api.Domain.Models;
using EmpireQms.Monitoring.Api.Domain.Repositories;

namespace EmpireQms.Monitoring.Api.Persistence.Repositories
{
    public class BreakLogEntryRepository : Repository<BreakLogEntry>, IBreakLogEntryRepository
    {
        private MonitoringContext _monitoringContext;

        public BreakLogEntryRepository(MonitoringContext context) : base(context, context.BreakLogEntries)
        {
            _monitoringContext = context;
        }
        public void UpdateBreakLogEntry(BreakLogEntry breakLogEntry)
        {
            _monitoringContext.Entry(breakLogEntry).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _monitoringContext.SaveChanges();
        }
    }
}
