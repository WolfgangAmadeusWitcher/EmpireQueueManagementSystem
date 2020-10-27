using EmpireQms.TicketDispenser.Api.Domain.Models;
using EmpireQms.TicketDispenser.Api.Domain.Repositories;

namespace EmpireQms.TicketDispenser.Api.Persistence.Repositories
{
    public class EmpireQueueRepository : Repository<EmpireQueue>, IEmpireQueueRepository
    {
        private TicketContext _ticketContext;
        public EmpireQueueRepository(TicketContext context) : base(context, context.EmpireQueues)
        {
            _ticketContext = context;
        }
    }
}
