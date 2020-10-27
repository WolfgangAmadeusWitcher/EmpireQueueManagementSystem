﻿using EmpireQms.Domain.Core.Events;
using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Integration.Events.EmpireQueues
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
