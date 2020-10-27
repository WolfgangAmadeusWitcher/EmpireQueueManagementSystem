using EmpireQms.Domain.Core.Events;
using EmpireQms.TicketDispenser.Api.Domain.Models;

namespace EmpireQms.TicketDispenser.Api.Integration.Events.Tickets
{
    public class TicketCreatedEvent : Event
    {
        public Ticket Ticket { get; set; }
        public TicketCreatedEvent(Ticket ticket)
        {
            Ticket = ticket;
        }
    }
}
