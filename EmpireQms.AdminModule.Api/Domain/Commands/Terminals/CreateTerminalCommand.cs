using EmpireQms.AdminModule.Api.Domain.Models;

namespace EmpireQms.AdminModule.Api.Domain.Commands
{
    public class CreateTerminalCommand : TerminalCommand
    {
        public CreateTerminalCommand(Terminal terminal)
        {
            CommandedTerminal = terminal;
        }
    }
}
