using EmpireQms.Domain.Core.Events;
using EmpireQms.SignageService.Api.Domain.Models;

namespace EmpireQms.SignageService.Api.Integration.Events.Terminals
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
