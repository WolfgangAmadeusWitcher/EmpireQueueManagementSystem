using EmpireQms.Domain.Core.Events;
using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Integration.Events.TicketCategories
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
