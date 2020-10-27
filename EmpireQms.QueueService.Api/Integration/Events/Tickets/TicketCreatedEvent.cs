using EmpireQms.Domain.Core.Events;
using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Integration.Events.Tickets
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
