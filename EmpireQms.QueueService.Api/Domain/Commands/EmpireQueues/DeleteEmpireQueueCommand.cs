using EmpireQms.Domain.Core.Commands;
using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Domain.Commands.EmpireQueues
{
    public class DeleteEmpireQueueCommand : Command
    {
        public TicketCategory TicketCategory { get; set; }
        public DeleteEmpireQueueCommand(TicketCategory ticketCategory)
        {
            TicketCategory = ticketCategory;
        }
    }
}
