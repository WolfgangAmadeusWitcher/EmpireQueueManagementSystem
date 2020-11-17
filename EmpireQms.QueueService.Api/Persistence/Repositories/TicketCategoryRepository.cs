using EmpireQms.QueueService.Api.Domain.Models;
using EmpireQms.QueueService.Api.Domain.Repositories;

namespace EmpireQms.QueueService.Api.Persistence.Repositories
{
    public class TicketCategoryRepository : Repository<TicketCategory>, ITicketCategoryRepository
    {
        private readonly QueueContext _queueContext;

        public TicketCategoryRepository(QueueContext context) : base(context, context.TicketCategories)
        {
            _queueContext = context;
        }
        public void UpdateTicketCategory(TicketCategory ticketCategory)
        {
            _queueContext.Entry(ticketCategory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _queueContext.SaveChanges();
        }
    }
}
