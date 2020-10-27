using EmpireQms.Domain.Core.Events;
using EmpireQms.Monitoring.Api.Domain.Models;

namespace EmpireQms.Monitoring.Api.Integration.Events.BreakLogEntries
{
    public class BreakLogEntryCreatedEvent : Event
    {
        public BreakLogEntry BreakLogEntryInstance { get; set; }
        public BreakLogEntryCreatedEvent(BreakLogEntry breakLogEntry)
        {
            BreakLogEntryInstance = breakLogEntry;
        }
    }
}
