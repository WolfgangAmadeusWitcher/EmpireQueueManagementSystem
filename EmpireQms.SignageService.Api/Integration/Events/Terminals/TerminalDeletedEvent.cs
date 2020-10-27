using EmpireQms.Domain.Core.Events;
using EmpireQms.SignageService.Api.Domain.Models;

namespace EmpireQms.SignageService.Api.Integration.Events.Terminals
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
