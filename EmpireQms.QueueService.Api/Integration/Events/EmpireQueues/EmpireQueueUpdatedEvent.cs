using EmpireQms.Domain.Core.Events;
using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Integration.Events.EmpireQueues
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
