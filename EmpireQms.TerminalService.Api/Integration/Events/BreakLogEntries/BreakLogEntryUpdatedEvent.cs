using EmpireQms.Domain.Core.Events;
using EmpireQms.TerminalService.Api.Domain.Models;

namespace EmpireQms.TerminalService.Api.Integration.Events.BreakLogEntries
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
