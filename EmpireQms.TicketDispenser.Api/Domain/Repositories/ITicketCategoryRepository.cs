using EmpireQms.TicketDispenser.Api.Domain.Models;

namespace EmpireQms.TicketDispenser.Api.Domain.Repositories
{
    public interface ITicketCategoryRepository : IRepository<TicketCategory>
    {
        void UpdateCategory(TicketCategory ticketCategory);
    }
}
