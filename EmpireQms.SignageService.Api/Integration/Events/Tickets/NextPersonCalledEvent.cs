using EmpireQms.Domain.Core.Events;

namespace EmpireQms.SignageService.Api.Integration.Events.Tickets
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
