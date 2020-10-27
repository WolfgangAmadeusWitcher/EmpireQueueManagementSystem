using EmpireQms.Domain.Core.Events;
using EmpireQms.TicketDispenser.Api.Domain.Models;

namespace EmpireQms.TicketDispenser.Api.Integration.Events.EmpireQueues
{
    public class EmpireQueueCreatedEvent : Event
    {
        public EmpireQueue EmpireQueue { get; set; }
        public EmpireQueueCreatedEvent(EmpireQueue empireQueue)
        {
            EmpireQueue = empireQueue;
        }
    }
}
