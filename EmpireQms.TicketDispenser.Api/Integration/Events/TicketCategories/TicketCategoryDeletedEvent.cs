using EmpireQms.Domain.Core.Events;
using EmpireQms.TicketDispenser.Api.Domain.Models;

namespace EmpireQms.TicketDispenser.Api.Integration.Events.TicketCategories
{
    public class TicketCategoryDeletedEvent : Event
    {
        public TicketCategory TicketCategory { get; set; }
        public TicketCategoryDeletedEvent(TicketCategory ticketCategory)
        {
            TicketCategory = ticketCategory;
        }
    }
}
