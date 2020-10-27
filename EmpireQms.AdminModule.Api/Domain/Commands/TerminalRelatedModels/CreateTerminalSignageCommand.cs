using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Commands;

namespace EmpireQms.AdminModule.Api.Domain.Commands.TerminalRelatedObjects
{
    public class CreateTerminalSignageCommand : Command
    {
        public TerminalSignage TerminalSignage { get; set; }
        public CreateTerminalSignageCommand(TerminalSignage terminalSignage)
        {
            TerminalSignage = terminalSignage;
        }
    }
}
