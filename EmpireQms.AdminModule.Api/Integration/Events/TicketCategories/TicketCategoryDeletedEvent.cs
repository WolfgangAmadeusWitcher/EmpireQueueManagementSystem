using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.AdminModule.Api.Domain.Events
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
