using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;
using System.Collections.Generic;

namespace EmpireQms.AdminModule.Api.Domain.Events.Terminals
{
    public class TerminalsSyncedEvent : Event
    {
        public List<Terminal> TerminalsTable { get; set; }
        public TerminalsSyncedEvent(List<Terminal> terminals)
        {
            TerminalsTable = terminals;
        }
    }
}
