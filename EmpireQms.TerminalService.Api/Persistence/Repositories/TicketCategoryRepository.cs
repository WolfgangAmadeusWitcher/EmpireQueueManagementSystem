using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.TerminalService.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmpireQms.TerminalService.Api.Persistence.Repositories
{
    public class TicketCategoryRepository : Repository<TicketCategory>, ITicketCategoryRepository
    {
        private TerminalContext _terminalContext;

        public TicketCategoryRepository(TerminalContext context) : base(context, context.TicketCategories)
        {
            _terminalContext = context;
        }
        public void UpdateTicketCategory(TicketCategory ticketCategory)
        {
            _terminalContext.Entry(ticketCategory).State = EntityState.Modified;
            _terminalContext.SaveChanges();
        }
    }
}
