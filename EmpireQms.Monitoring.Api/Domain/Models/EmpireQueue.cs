namespace EmpireQms.Monitoring.Api.Domain.Models
{
    public class EmpireQueue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double QueueWeight { get; set; }
        public int ActiveWaitersCount { get; set; }
    }
}
