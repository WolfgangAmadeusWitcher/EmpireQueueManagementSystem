using EmpireQms.Domain.Core.Events;
using EmpireQms.TerminalService.Api.Domain.Models;

namespace EmpireQms.TerminalService.Api.Integration.Events.TicketCategories
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
