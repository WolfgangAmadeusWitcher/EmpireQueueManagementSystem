using EmpireQms.Domain.Core.Events;
using EmpireQms.Monitoring.Api.Domain.Models;

namespace EmpireQms.Monitoring.Api.Integration.Events.EmpireQueues
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
