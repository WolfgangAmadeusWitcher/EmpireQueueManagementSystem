using EmpireQms.TicketDispenser.Api.Domain.Models;

namespace EmpireQms.TicketDispenser.Api.Domain.Repositories
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        void UpdateTicket(Ticket ticket);
    }
}
