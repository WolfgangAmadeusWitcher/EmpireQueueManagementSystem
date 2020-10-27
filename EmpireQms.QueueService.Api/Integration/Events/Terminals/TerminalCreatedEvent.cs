using EmpireQms.Domain.Core.Events;
using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Integration.Events.Terminals
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
