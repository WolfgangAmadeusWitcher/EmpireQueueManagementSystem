using EmpireQms.Domain.Core.Commands;
using EmpireQms.TerminalService.Api.Domain.Models;

namespace EmpireQms.TerminalService.Api.Domain.Commands
{
    public class CreateBreakLogEntryCommand : Command
    {
        public BreakLogEntry BreakLogEntryInstance { get; set; }
        public CreateBreakLogEntryCommand(BreakLogEntry breakLogEntry)
        {
            BreakLogEntryInstance = breakLogEntry;
        }
    }
}
