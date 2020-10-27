using EmpireQms.QueueService.Api.Domain.Models;
using EmpireQms.QueueService.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmpireQms.QueueService.Api.Persistence.Repositories
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        private QueueContext _queueContext;

        public TicketRepository(QueueContext context) : base(context, context.Tickets)
        {
            _queueContext = context;
        }

        public void UpdateTicket(Ticket ticket)
        {
            _queueContext.Entry(ticket).State = EntityState.Modified;
            _queueContext.SaveChanges();
        }
    }
}
