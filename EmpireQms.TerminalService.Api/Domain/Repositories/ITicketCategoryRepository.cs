using EmpireQms.TerminalService.Api.Domain.Models;

namespace EmpireQms.TerminalService.Api.Domain.Repositories
{
    public interface ITicketCategoryRepository : IRepository<TicketCategory>
    {
        void UpdateTicketCategory(TicketCategory ticketCategory);
    }
}
