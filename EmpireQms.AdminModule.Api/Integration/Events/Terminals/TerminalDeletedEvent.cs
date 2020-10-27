using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.AdminModule.Api.Domain.Events.Terminals
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
