using System;

namespace EmpireQms.TerminalService.Api.Domain.Models
{
    public enum BreakState
    {
        Open,
        AllowedLimitExceeded,
        Closed
    }
    public class BreakLogEntry
    {
        public int Id { get; set; }
        public string BreakReason { get; set; }
        public DateTime BreakStartTime { get; set; }
        public DateTime BreakEndTime { get; set; }
        public int TerminalId { get; set; }
        public BreakState BreakState { get; set; }
    }
}
