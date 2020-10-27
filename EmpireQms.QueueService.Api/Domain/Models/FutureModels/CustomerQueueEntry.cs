using System;

namespace EmpireQms.QueueService.Api.Domain.Models
{
    public class CustomerQueueEntry
    {
        public int Id { get; set; }
        public DateTime EnqueueTime { get; set; }
        public DateTime DequeueTime { get; set; }
        public int CustomerId { get; set; }
        public int QueueId { get; set; }
        public int TerminalId { get; set; }
    }
}
