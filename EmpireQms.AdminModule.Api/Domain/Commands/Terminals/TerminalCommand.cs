using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Commands;

namespace EmpireQms.AdminModule.Api.Domain.Commands
{
    public class TerminalCommand : Command
    {
        public Terminal CommandedTerminal { get; set; }
    }
}
