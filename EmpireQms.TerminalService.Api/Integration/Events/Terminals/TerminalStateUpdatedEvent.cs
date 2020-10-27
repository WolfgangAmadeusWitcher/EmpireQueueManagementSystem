using EmpireQms.Domain.Core.Events;
using EmpireQms.TerminalService.Api.Domain.Models;

namespace EmpireQms.TerminalService.Api.Integration.Events.Terminals
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
