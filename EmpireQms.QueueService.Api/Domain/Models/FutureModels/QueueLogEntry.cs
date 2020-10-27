using System;

namespace EmpireQms.QueueService.Api.Domain.Models
{
    public enum QueueState
    {
        Open,
        Close,
        inactive
    }
    public enum QueuePerformance
    {
        HighPerformance,
        Normal,
        Underperforming,
        Critical,
        NoServe
    }
    public class QueueLogEntry
    {
        public int Id { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public int ServedCustomerCount { get; set; }
        public double AverageWaitingTime { get; set; }
        public QueueState CurrentQueueState { get; set; }
        public QueuePerformance CurrentPerformanceState { get; set; }
        public QueuePerformance PreviousPerformanceState { get; set; }
    }
}
