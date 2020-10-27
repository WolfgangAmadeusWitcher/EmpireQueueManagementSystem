using EmpireQms.Domain.Core.Events;
using EmpireQms.TerminalService.Api.Domain.Models;

namespace EmpireQms.TerminalService.Api.Integration.Events.BreakLogEntries
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
