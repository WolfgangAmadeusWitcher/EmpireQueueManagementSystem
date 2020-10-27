using EmpireQms.Domain.Core.Events;
using EmpireQms.SignageService.Api.Domain.Models;
using System.Collections.Generic;

namespace EmpireQms.SignageService.Api.Integration.Events.Terminals
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
