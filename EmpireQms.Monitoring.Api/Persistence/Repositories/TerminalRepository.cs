using EmpireQms.Monitoring.Api.Domain.Models;
using EmpireQms.Monitoring.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace EmpireQms.Monitoring.Api.Persistence.Repositories
{
    public class TerminalRepository : Repository<Terminal>, ITerminalRepository
    {
        private MonitoringContext _monitoringContext;

        public TerminalRepository(MonitoringContext context) : base(context, context.Terminals)
        {
            _monitoringContext = context;
        }
        public void UpdateTerminal(Terminal terminal)
        {
            _monitoringContext.Entry(terminal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _monitoringContext.SaveChanges();
        }

        public override IEnumerable<Terminal> GetAll()
        {
            var terminals = base.GetAll();
            var breakLogEntries = _monitoringContext.BreakLogEntries.ToList();
            foreach(var terminal in terminals)
            {
                var filteredLogs = breakLogEntries.Where(ble => ble.TerminalId == terminal.Id);
                if (filteredLogs.Any())
                {
                    terminal.BreakLogEntries.AddRange(filteredLogs);
                }
            }

            return terminals;
        }
    }
}
