using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.AdminModule.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmpireQms.AdminModule.Api.Persistence.Repositories
{
    public class TicketCategoryRepository : Repository<TicketCategory>, ITicketCategoryRepository
    {
        public SettingsContext SettingsContext => Context as SettingsContext;

        public TicketCategoryRepository(SettingsContext context) : base(context, context.TicketCategories)
        {
        }

        public void UpdateTicketCategory(TicketCategory ticketCategory)
        {
            SettingsContext.Entry(ticketCategory).State = EntityState.Modified;
        }
    }
}
