using System.Collections.Generic;

namespace EmpireQms.SignageService.Api.Domain.Models
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
            TerminalSignages = new List<TerminalSignage>();
        }
        public int Id { get; set; }
        public string Alias { get; set; }
        public TerminalStatus Status { get; set; }
        public List<TerminalSignage> TerminalSignages { get; set; }
        public int? CalledTicketNumber { get; set; }
    }
}
