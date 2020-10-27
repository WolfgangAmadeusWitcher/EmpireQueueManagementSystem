using System.Collections.Generic;

namespace EmpireQms.Monitoring.Api.Domain.Models
{
    public enum TerminalStatus
    {
        Online = 1,
        Serving,
        Break,
        Idle,
        Offline
    }
    public class Terminal
    {
        public Terminal()
        {
            BreakLogEntries = new List<BreakLogEntry>();
        }
        public int Id { get; set; }
        public string Alias { get; set; }
        public TerminalStatus Status { get; set; }
        public List<BreakLogEntry> BreakLogEntries { get; set; }
    }
}
