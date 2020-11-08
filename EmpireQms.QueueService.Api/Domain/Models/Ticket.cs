using System;

namespace EmpireQms.QueueService.Api.Domain.Models
{
    public enum TicketStatus
    {
        Created = 0,
        Waiting = 1,
        Called,
        Served, //Serving
        ReQueued,
        Missed,
        ReCalled,
        OperatorCall,
        StandBy,
        Closed,
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
