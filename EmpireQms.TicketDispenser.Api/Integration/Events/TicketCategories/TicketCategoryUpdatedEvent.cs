using EmpireQms.TicketDispenser.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.TicketDispenser.Api.Integration.Events.TicketCategories
{
    public class TicketCategoryUpdatedEvent : Event
    {
        public TicketCategory TicketCategory { get; set; }
        public TicketCategoryUpdatedEvent(TicketCategory ticketCategory)
        {
            TicketCategory = ticketCategory;
        }
    }
}
