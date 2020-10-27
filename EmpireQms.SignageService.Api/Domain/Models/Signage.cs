using System.Collections.Generic;

namespace EmpireQms.SignageService.Api.Domain.Models
{
    public class Signage
    {
        public Signage()
        {
            TerminalSignages = new List<TerminalSignage>();
        }
        public int Id { get; set; }
        public string Alias { get; set; }
        public string ConnectionId { get; set; }
        public List<TerminalSignage> TerminalSignages { get; set; }
    }
}
