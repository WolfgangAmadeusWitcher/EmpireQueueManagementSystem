using EmpireQms.Monitoring.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.Monitoring.Api.Integration.Events.Terminals
{
    public class TerminalDeletedEvent : Event
    {
        public Terminal TerminalInstance { get; set; }
        public TerminalDeletedEvent(Terminal terminal)
        {
            TerminalInstance = terminal;
        }
    }
}
