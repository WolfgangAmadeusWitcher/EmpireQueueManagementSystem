using EmpireQms.Monitoring.Api.Domain.Models;

namespace EmpireQms.Monitoring.Api.Domain.Repositories
{
    public interface IEmpireQueueRepository : IRepository<EmpireQueue>
    {
        void UpdateEmpireQueue(EmpireQueue empireQueue);
    }
}
