using EmpireQms.Domain.Core.Events;
using EmpireQms.TerminalService.Api.Domain.Models;
using System.Collections.Generic;

namespace EmpireQms.TerminalService.Api.Integration.Events.Terminals
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
