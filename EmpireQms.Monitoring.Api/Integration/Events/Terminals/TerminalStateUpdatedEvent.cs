using EmpireQms.Domain.Core.Events;
using EmpireQms.Monitoring.Api.Domain.Models;

namespace EmpireQms.Monitoring.Api.Integration.Events.Terminals
{
    public class TerminalStateUpdatedEvent : Event
    {
        public Terminal TerminalInstance { get; set; }
        public TerminalStateUpdatedEvent(Terminal terminal)
        {
            TerminalInstance = terminal;
        }
    }
}
