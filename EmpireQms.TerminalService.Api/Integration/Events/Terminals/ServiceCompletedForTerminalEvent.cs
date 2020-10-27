using EmpireQms.Domain.Core.Events;

namespace EmpireQms.TerminalService.Api.Integration.Events.Terminals
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
