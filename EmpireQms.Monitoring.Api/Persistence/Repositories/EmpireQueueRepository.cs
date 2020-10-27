using EmpireQms.Monitoring.Api.Domain.Models;
using EmpireQms.Monitoring.Api.Domain.Repositories;

namespace EmpireQms.Monitoring.Api.Persistence.Repositories
{
    public class EmpireQueueRepository : Repository<EmpireQueue>, IEmpireQueueRepository
    {
        private MonitoringContext _monitoringContext;

        public EmpireQueueRepository(MonitoringContext context) : base(context, context.EmpireQueues)
        {
            _monitoringContext = context;
        }
        public void UpdateEmpireQueue(EmpireQueue empireQueue)
        {
            _monitoringContext.Entry(empireQueue).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _monitoringContext.SaveChanges();
        }
    }
}
