using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.TerminalService.Api.Integration.Events.Terminals
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
