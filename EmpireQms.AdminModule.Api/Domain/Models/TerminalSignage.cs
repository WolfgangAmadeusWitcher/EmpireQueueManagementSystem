using Newtonsoft.Json;

namespace EmpireQms.AdminModule.Api.Domain.Models
{
    public class TerminalSignage
    {
        [JsonIgnore]
        public Terminal Terminal { get; set; }
        public int TerminalId { get; set; }
        [JsonIgnore]
        public Signage Signage { get; set; }
        public int SignageId { get; set; }
    }
}
