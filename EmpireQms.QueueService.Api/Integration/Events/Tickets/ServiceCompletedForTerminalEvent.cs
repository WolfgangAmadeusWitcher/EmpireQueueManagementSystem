using EmpireQms.Domain.Core.Events;

namespace EmpireQms.QueueService.Api.Integration.Events.Tickets
{
    public class ServiceCompletedForTerminalEvent : Event
    {
        public int TerminalId { get; set; }
        public ServiceCompletedForTerminalEvent(int terminalId)
        {
            TerminalId = terminalId;
        }
    }
}
