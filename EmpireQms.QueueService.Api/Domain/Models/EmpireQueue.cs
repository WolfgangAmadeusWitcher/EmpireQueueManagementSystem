namespace EmpireQms.QueueService.Api.Domain.Models
{
    public class EmpireQueue
    {
        public int Id { get; set; }
        public int TicketCategoryId { get; set; }
        public string Name { get; set; }
        public double QueueWeight { get; set; }
        public int? MaxAllowedCustomers { get; set; }
        public int ActiveWaitersCount { get; set; }
    }
}
