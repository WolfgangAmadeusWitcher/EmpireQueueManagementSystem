using EmpireQms.Domain.Core.Commands;

namespace EmpireQms.QueueService.Api.Domain.Commands.Tickets
{
    public class CompleteServiceForTerminalCommand : Command
    {
        public int TerminalId { get; set; }
        public CompleteServiceForTerminalCommand(int terminalId)
        {
            TerminalId = terminalId;
        }
    }
}
