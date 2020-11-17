using EmpireQms.QueueService.Api.Domain.Models;
using EmpireQms.QueueService.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmpireQms.QueueService.Api.Persistence.Repositories
{
    public class QueueRepository : Repository<EmpireQueue>, IQueueRepository
    {
        private readonly QueueContext _queueContext;

        public QueueRepository(QueueContext context) : base(context, context.EmpireQueues)
        {
            _queueContext = context;
        }

        public void UpdateQueue(EmpireQueue empireQueue)
        {
            _queueContext.Entry(empireQueue).State = EntityState.Modified;
            _queueContext.SaveChanges();
        }
    }
}
