using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Domain.Repositories
{
    public interface ITicketCategoryRepository : IRepository<TicketCategory>
    {
        void UpdateTicketCategory(TicketCategory ticketCategory);
    }
}
