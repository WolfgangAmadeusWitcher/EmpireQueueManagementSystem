using System.Collections.Generic;

namespace EmpireQms.AdminModule.Api.Domain.Models
{
    public enum TerminalStatus
    {
        Online = 1,
        Serving,
        Break,
        Idle,
        Offline
    }
    public class Terminal : Setting
    {
        public Terminal()
        {
            TerminalCategories = new List<TerminalCategory>();
            TerminalSignages = new List<TerminalSignage>();
        }
        public string Alias { get; set; }
        public List<TerminalCategory> TerminalCategories { get; set; }
        public List<TerminalSignage> TerminalSignages { get; set; }
        public TerminalStatus Status { get; set; }
    }
}
