using System;

namespace EmpireQms.QueueService.Api.Domain.Models
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
        public int QueueId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ServiceCompletedDate { get; set; }
        public int TicketCategoryId { get; set; }
        public TicketStatus TicketStatus { get; set; }
    }
}
