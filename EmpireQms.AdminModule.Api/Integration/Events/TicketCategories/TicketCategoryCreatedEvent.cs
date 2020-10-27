using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.AdminModule.Api.Domain.Events
{
    public class TicketCategoryCreatedEvent : Event
    {
        public TicketCategory TicketCategory { get; set; }
        public TicketCategoryCreatedEvent(TicketCategory ticketCategory)
        {
            TicketCategory = ticketCategory;
        }
    }
}
