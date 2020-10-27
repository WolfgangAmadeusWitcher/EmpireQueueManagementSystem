using EmpireQms.TicketDispenser.Api.Domain.Models;
using EmpireQms.TicketDispenser.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmpireQms.TicketDispenser.Api.Persistence.Repositories
{
    public class TicketCategoryRepository : Repository<TicketCategory>, ITicketCategoryRepository
    {
        private TicketContext _ticketContext;
        public TicketCategoryRepository(TicketContext context) : base(context, context.TicketCategories)
        {
            _ticketContext = context;
        }

        public void UpdateCategory(TicketCategory ticketCategory)
        {
            _ticketContext.Entry(ticketCategory).State = EntityState.Modified;
            _ticketContext.SaveChanges();
        }
    }
}
