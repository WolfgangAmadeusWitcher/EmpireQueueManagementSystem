using System.Collections.Generic;

namespace EmpireQms.AdminModule.Api.Domain.Models
{
    public class Signage : Setting
    {
        public Signage()
        {
            TerminalSignages = new List<TerminalSignage>();
        }
        public string Alias { get; set; }
        public List<TerminalSignage> TerminalSignages { get; set; }
    }
}
