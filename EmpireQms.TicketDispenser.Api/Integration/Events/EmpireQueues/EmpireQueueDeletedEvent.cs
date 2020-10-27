using EmpireQms.Domain.Core.Events;
using EmpireQms.TicketDispenser.Api.Domain.Models;

namespace EmpireQms.TicketDispenser.Api.Integration.Events.EmpireQueues
{
    public class EmpireQueueDeletedEvent : Event
    {
        public EmpireQueue EmpireQueue { get; set; }
        public EmpireQueueDeletedEvent(EmpireQueue empireQueue)
        {
            EmpireQueue = empireQueue;
        }
    }
}
