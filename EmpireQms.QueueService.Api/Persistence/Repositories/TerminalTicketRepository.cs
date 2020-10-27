using EmpireQms.QueueService.Api.Domain.Models;
using EmpireQms.QueueService.Api.Domain.Repositories;

namespace EmpireQms.QueueService.Api.Persistence.Repositories
{
    public class TerminalTicketRepository : Repository<TerminalTicket>, ITerminalTicketRepository
    {
        public TerminalTicketRepository(QueueContext context) : base(context, context.TerminalTickets)
        {

        }
    }
}
