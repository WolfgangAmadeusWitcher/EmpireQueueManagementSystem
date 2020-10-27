using Newtonsoft.Json;

namespace EmpireQms.AdminModule.Api.Domain.Models
{
    public class TerminalCategory
    {
        [JsonIgnore]
        public TicketCategory TicketCategory { get; set; }
        public int TicketCategoryId { get; set; }
        [JsonIgnore]
        public Terminal Terminal { get; set; }
        public int TerminalId { get; set; }
    }
}
