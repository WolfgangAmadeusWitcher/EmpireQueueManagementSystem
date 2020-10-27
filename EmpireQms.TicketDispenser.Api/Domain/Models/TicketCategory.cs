namespace EmpireQms.TicketDispenser.Api.Domain.Models
{
    public class TicketCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FirstTicketNumber { get; set; }
        public int LastTicketNumber { get; set; }
    }
}
