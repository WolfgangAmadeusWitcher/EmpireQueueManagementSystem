using System.Collections.Generic;

namespace EmpireQms.AdminModule.Api.Domain.Models
{
    public class TicketCategory : Setting
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FirstTicketNumber { get; set; }
        public int LastTicketNumber { get; set; }
        public double PriorityCoefficient { get; set; }
        public List<TerminalCategory> TerminalCategories { get; set; }
    }
}
