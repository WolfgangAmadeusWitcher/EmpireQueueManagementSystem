using EmpireQms.Domain.Core.Bus;
using EmpireQms.Domain.Core.Commands;
using EmpireQms.TicketDispenser.Api.Domain;
using EmpireQms.TicketDispenser.Api.Domain.Repositories;
using EmpireQms.TicketDispenser.Api.Persistence.Repositories;

namespace EmpireQms.TicketDispenser.Api.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TicketContext _context;
        private readonly IEventBus _eventBus;

        public IEmpireQueueRepository EmpireQueues { get; private set; }
        public ITicketCategoryRepository TicketCategories { get; private set; }
        public ITicketRepository Tickets { get; private set; }

        public UnitOfWork(TicketContext context, IEventBus eventBus)
        {
            _context = context;
            _eventBus = eventBus;
            TicketCategories = new TicketCategoryRepository(context);
            Tickets = new TicketRepository(context);
            EmpireQueues = new EmpireQueueRepository(context);
        }
        public void SourceEvent<T>(T command) where T : Command
        {
            _eventBus.SendCommand(command);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
