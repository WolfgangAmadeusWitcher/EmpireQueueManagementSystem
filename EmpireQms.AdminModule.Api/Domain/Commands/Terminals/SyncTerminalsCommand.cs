using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Commands;
using System.Collections.Generic;

namespace EmpireQms.AdminModule.Api.Domain.Commands.Terminals
{
    public class SyncTerminalsCommand : Command
    {
        public List<Terminal> TerminalsTable { get; set; }
        public SyncTerminalsCommand(List<Terminal> terminals)
        {
            TerminalsTable = terminals;
        }
    }
}
