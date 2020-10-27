using System;

namespace EmpireQms.QueueService.Api.Domain.Models
{
    public class CustomerLogEntry
    {
        public int Id { get; set; }
        public string CurrentState { get; set; }
        public string PreviousState { get; set; }
        public DateTime EntryTime { get; set; }
    }
}
