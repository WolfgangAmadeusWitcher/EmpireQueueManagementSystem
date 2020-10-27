using EmpireQms.Domain.Core.Commands;
using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Domain.Commands
{
    public class GetNextCustomerCommand : Command
    {
        public Ticket Ticket { get; set; }
        public int TerminalId { get; set; }
        public GetNextCustomerCommand(Ticket ticket, int terminalId)
        {
            Ticket = ticket;
            TerminalId = terminalId;
        }
    }
}
