using EmpireQms.Domain.Core.Commands;
using EmpireQms.TerminalService.Api.Domain.Models;

namespace EmpireQms.TerminalService.Api.Domain.Commands
{
    public class UpdateTerminalStateCommand : Command
    {
        public Terminal TerminalInstance { get; set; }
        public UpdateTerminalStateCommand(Terminal terminal)
        {
            TerminalInstance = terminal;
        }
    }
}
