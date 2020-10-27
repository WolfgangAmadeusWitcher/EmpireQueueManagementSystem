using EmpireQms.Domain.Core.Events;
using EmpireQms.SignageService.Api.Domain.Models;

namespace EmpireQms.SignageService.Api.Integration.Events.TerminalSignages
{
    public class TerminalSignageDeletedEvent : Event
    {
        public TerminalSignage TerminalSignage { get; set; }
        public TerminalSignageDeletedEvent(TerminalSignage terminalSignage)
        {
            TerminalSignage = terminalSignage;
        }
    }
}
