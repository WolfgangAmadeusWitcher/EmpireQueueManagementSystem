using EmpireQms.Domain.Core.Events;
using EmpireQms.Monitoring.Api.Domain.Models;

namespace EmpireQms.Monitoring.Api.Integration.Events.BreakLogEntries
{
    public class BreakLogEntryUpdatedEvent : Event
    {
        public BreakLogEntry BreakLogEntryInstance { get; set; }
        public BreakLogEntryUpdatedEvent(BreakLogEntry breakLogEntry)
        {
            BreakLogEntryInstance = breakLogEntry;
        }
    }
}
