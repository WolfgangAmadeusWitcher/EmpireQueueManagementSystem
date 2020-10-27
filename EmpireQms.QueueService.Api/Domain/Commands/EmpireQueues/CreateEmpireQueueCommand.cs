using EmpireQms.Domain.Core.Commands;
using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Domain.Commands.EmpireQueues
{
    public class CreateEmpireQueueCommand : Command
    {
        public TicketCategory TicketCategory { get; set; }
        public CreateEmpireQueueCommand(TicketCategory ticketCategory)
        {
            TicketCategory = ticketCategory;
        }
    }
}
