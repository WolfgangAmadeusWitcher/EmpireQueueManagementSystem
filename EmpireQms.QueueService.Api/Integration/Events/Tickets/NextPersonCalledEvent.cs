using EmpireQms.Domain.Core.Events;
using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Integration.Events.Tickets
{
    public class NextPersonCalledEvent : Event
    {
        public int TerminalId { get; set; }
        public int TicketNumber { get; set; }
        public NextPersonCalledEvent(int ticketNumber, int terminalId)
        {
            TerminalId = terminalId;
            TicketNumber = ticketNumber;
        }
    }
}
