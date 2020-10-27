using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Domain.Repositories
{
    public interface IQueueRepository : IRepository<EmpireQueue>
    {
        void UpdateQueue(EmpireQueue empireQueue);
    }
}
