using EmpireQms.Domain.Core.Events;
using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Integration.Events.TicketCategories
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
