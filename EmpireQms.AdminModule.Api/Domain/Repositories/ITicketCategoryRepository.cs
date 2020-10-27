using EmpireQms.AdminModule.Api.Domain.Models;

namespace EmpireQms.AdminModule.Api.Domain.Repositories
{
    public interface ITicketCategoryRepository : IRepository<TicketCategory>
    {
        void UpdateTicketCategory(TicketCategory ticketCategory);
    }
}
