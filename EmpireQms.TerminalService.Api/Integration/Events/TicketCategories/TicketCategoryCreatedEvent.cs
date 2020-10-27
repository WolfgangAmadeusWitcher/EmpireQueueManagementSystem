using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.TerminalService.Api.Integration.Events.TicketCategories
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
