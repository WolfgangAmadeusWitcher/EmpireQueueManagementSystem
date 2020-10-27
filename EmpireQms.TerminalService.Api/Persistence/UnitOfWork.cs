using EmpireQms.TerminalService.Api.Domain;
using EmpireQms.TerminalService.Api.Domain.Repositories;
using EmpireQms.TerminalService.Api.Persistence.Repositories;
using EmpireQms.Domain.Core.Bus;
using EmpireQms.Domain.Core.Commands;
using EmpireQms.TerminalService.Api.Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace EmpireQms.TerminalService.Api.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TerminalContext _context;
        private readonly IEventBus _eventBus;
        private readonly IHubContext<TerminalHub> _hub;

        public ITerminalRepository Terminals { get; private set; }
        public ITerminalCategoryRepository TerminalCategories { get; private set; }
        public ITicketCategoryRepository TicketCategories { get; set; }
        public IBreakLogEntryRepository BreakLogEntries { get; private set; }

        public UnitOfWork(TerminalContext context, IEventBus eventBus, IHubContext<TerminalHub> terminalHub)
        {
            _context = context;
            _eventBus = eventBus;
            _hub = terminalHub;
            Terminals = new TerminalRepository(context);
            BreakLogEntries = new BreakLogEntryRepository(context);
            TicketCategories = new TicketCategoryRepository(context);
            TerminalCategories = new TerminalCategoryRepository(context);
        }

        public void SourceEvent<T>(T command) where T : Command
        {
            _eventBus.SendCommand(command);
        }
        public void BroadcastServerEvent<T>(string eventCode, T eventModel) where T : class
        {
            _hub.Clients.All.SendAsync(eventCode, eventModel);
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
