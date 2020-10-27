using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.AdminModule.Api.Domain.Events.TerminalRelatedObjects
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
