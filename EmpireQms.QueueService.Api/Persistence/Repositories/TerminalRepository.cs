using EmpireQms.QueueService.Api.Domain.Models;
using EmpireQms.QueueService.Api.Domain.Repositories;

namespace EmpireQms.QueueService.Api.Persistence.Repositories
{
    public class TerminalRepository : Repository<Terminal>, ITerminalRepository
    {
        private QueueContext _queueContext;

        public TerminalRepository(QueueContext context) : base(context, context.Terminals)
        {
            _queueContext = context;
        }
        public void UpdateTerminal(Terminal terminal)
        {
            _queueContext.Entry(terminal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _queueContext.SaveChanges();
        }
    }
}
