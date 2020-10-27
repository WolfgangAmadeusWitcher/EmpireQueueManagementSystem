using EmpireQms.Domain.Core.Events;
using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Integration.Events.TicketCategories
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
