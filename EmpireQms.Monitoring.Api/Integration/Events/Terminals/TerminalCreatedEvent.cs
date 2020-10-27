using EmpireQms.Monitoring.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.Monitoring.Api.Integration.Events.Terminals
{
    public class TerminalCreatedEvent : Event
    {
        public Terminal TerminalInstance { get; set; }
        public TerminalCreatedEvent(Terminal terminal)
        {
            TerminalInstance = terminal;
        }
    }
}
