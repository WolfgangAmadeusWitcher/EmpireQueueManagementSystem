using EmpireQms.Domain.Core.Events;
using EmpireQms.SignageService.Api.Domain.Models;

namespace EmpireQms.SignageService.Api.Integration.Events.Terminals
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
