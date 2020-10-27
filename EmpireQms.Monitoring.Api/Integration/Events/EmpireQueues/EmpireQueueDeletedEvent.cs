using EmpireQms.Domain.Core.Events;
using EmpireQms.Monitoring.Api.Domain.Models;

namespace EmpireQms.Monitoring.Api.Integration.Events.EmpireQueues
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
