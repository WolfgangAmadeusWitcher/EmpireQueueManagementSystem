using System.Diagnostics;

namespace EmpireQms.QueueService.Api.Domain.Models
{
    public class TicketCategory
    {
        public int Id { get; set; }
        public double PriorityCoefficient { get; set; }
        public string Name { get; set; }
    }
}
