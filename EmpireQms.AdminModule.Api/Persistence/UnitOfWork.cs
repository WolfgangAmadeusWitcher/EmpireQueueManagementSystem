using EmpireQms.AdminModule.Api.Domain;
using EmpireQms.AdminModule.Api.Domain.Repositories;
using EmpireQms.AdminModule.Api.Persistence.Repositories;
using EmpireQms.Domain.Core.Bus;
using EmpireQms.Domain.Core.Commands;

namespace EmpireQms.AdminModule.Api.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SettingsContext _context;
        private readonly IEventBus _eventBus;
        public ITicketCategoryRepository TicketCategories { get; private set; }
        public ITerminalRepository Terminals { get; private set; }
        public ISignageRepository Signages { get; private set;}

        public UnitOfWork(SettingsContext context, IEventBus eventBus)
        {
            _context = context;
            _eventBus = eventBus;
            TicketCategories = new TicketCategoryRepository(context);
            Terminals = new TerminalRepository(context);
            Signages = new SignageRepository(context);

            //var signageSyncCommand = new SyncSignagesCommand(Signages.GetAll());
            //SourceEvent(signageSyncCommand);

            //var terminalsSyncCommand = new SyncTerminalsCommand(Terminals.GetAll());
            //SourceEvent(terminalsSyncCommand);
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
