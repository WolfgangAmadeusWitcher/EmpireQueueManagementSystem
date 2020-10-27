using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Commands;

namespace EmpireQms.AdminModule.Api.Domain.Commands.TerminalRelatedObjects
{
    public class DeleteTerminalSignageCommand : Command
    {
        public TerminalSignage TerminalSignage { get; set; }
        public DeleteTerminalSignageCommand(TerminalSignage terminalSignage)
        {
            TerminalSignage = terminalSignage;
        }
    }
}
