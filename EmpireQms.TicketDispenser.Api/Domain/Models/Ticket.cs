using System;

namespace EmpireQms.TicketDispenser.Api.Domain.Models
{
    public enum TicketStatus
    {
        Waiting = 1,
        Called,
        Served
    }
    public class Ticket
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int TicketCategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public TicketStatus TicketStatus { get; set; }
    }
}
