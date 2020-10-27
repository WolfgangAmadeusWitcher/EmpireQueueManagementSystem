using EmpireQms.Domain.Core.Events;
using EmpireQms.SignageService.Api.Domain.Models;

namespace EmpireQms.SignageService.Api.Integration.Events.TerminalSignages
{
    public class TerminalSignageCreatedEvent : Event
    {
        public TerminalSignage TerminalSignage { get; set; }
        public TerminalSignageCreatedEvent(TerminalSignage terminalSignage)
        {
            TerminalSignage = terminalSignage;
        }
    }
}
