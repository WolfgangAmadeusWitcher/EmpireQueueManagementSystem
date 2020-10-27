using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.TerminalService.Api.Integration.Events.Terminals
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
