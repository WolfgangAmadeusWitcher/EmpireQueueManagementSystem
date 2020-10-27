namespace EmpireQms.TicketDispenser.Api.Domain.Models
{
    public class EmpireQueue
    {
        public int Id { get; set; }
        public int TicketCategoryId { get; set; }
        public int? LastIssuedTicketNumber { get; set; }
    }
}
