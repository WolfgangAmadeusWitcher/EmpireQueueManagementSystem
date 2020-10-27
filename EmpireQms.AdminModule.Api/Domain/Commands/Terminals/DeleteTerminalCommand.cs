using EmpireQms.AdminModule.Api.Domain.Models;

namespace EmpireQms.AdminModule.Api.Domain.Commands
{
    public class DeleteTerminalCommand : TerminalCommand
    {
        public DeleteTerminalCommand(Terminal terminal)
        {
            CommandedTerminal = terminal;
        }
    }
}
