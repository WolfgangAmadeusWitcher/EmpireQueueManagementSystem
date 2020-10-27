using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.AdminModule.Api.Domain.Events
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
