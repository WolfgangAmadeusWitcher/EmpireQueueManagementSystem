using EmpireQms.Domain.Core.Events;
using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Integration.Events.Terminals
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
