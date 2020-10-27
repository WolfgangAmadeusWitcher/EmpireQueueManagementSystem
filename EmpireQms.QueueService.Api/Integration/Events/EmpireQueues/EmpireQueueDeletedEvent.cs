using EmpireQms.Domain.Core.Events;
using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Integration.Events.EmpireQueues
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
