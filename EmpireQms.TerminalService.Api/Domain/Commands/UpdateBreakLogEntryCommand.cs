using EmpireQms.Domain.Core.Commands;
using EmpireQms.TerminalService.Api.Domain.Models;

namespace EmpireQms.TerminalService.Api.Domain.Commands
{
    public class UpdateBreakLogEntryCommand : Command
    {
        public BreakLogEntry BreakLogEntryInstance { get; set; }
        public UpdateBreakLogEntryCommand(BreakLogEntry breakLogEntry)
        {
            BreakLogEntryInstance = breakLogEntry;
        }
    }
}
