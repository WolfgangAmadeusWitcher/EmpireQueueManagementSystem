using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.AdminModule.Api.Domain.Events.Terminals
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
