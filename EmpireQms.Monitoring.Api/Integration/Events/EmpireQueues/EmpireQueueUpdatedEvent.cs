using EmpireQms.Domain.Core.Events;
using EmpireQms.Monitoring.Api.Domain.Models;

namespace EmpireQms.Monitoring.Api.Integration.Events.EmpireQueues
{
    public class EmpireQueueUpdatedEvent : Event
    {
        public EmpireQueue EmpireQueue { get; set; }
        public EmpireQueueUpdatedEvent(EmpireQueue empireQueue)
        {
            EmpireQueue = empireQueue;
        }
    }
}
