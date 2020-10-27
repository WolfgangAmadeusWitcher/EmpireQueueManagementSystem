using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.AdminModule.Api.Domain.Events.TerminalRelatedObjects
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
