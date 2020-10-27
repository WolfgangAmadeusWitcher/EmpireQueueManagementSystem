using System;
using System.Collections.Generic;

namespace EmpireQms.QueueService.Api.Domain.Models
{
    public enum CustomerState
    {
        ProvidingInfo,
        SelectingServiceCategory,
        SegmentQueried,
        Enqueued, 
        Passed,
        Waiting,
        Served
    }
    public class Customer
    {
        public int Id { get; set; }
        public int SegmentId { get; set; }
        public List<CustomerQueueEntry> QueueEntries { get; set; }
        public TimeSpan TotalWaitingTime { get; set; }
        public int TicketId { get; set; }
    }
}
