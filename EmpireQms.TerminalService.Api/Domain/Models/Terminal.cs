using System.Collections.Generic;

namespace EmpireQms.TerminalService.Api.Domain.Models
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
        public string ConnectionId { get; set; }
        public virtual ICollection<BreakLogEntry> BreakLogEntries { get; set; }
    }
}
