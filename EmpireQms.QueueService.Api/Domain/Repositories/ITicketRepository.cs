using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Domain.Repositories
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        void UpdateTicket(Ticket ticket);
    }
}
