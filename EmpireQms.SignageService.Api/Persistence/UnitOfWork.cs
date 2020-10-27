using EmpireQms.Domain.Core.Bus;
using EmpireQms.Domain.Core.Commands;
using EmpireQms.SignageService.Api.Domain;
using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Domain.Repositories;
using EmpireQms.SignageService.Api.Persistence.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace EmpireQms.SignageService.Api.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SignageContext _context;
        private readonly IEventBus _eventBus;
        private readonly IHubContext<SignageHub> _hub;

        public ITerminalRepository Terminals { get; private set; }
        public ISignageRepository Signages { get; private set; }
        public ITerminalSignageRepository TerminalSignages { get; private set; }
        public UnitOfWork(SignageContext context, IEventBus eventBus, IHubContext<SignageHub> signageHub)
        {
            _context = context;
            _eventBus = eventBus;
            _hub = signageHub;
            Terminals = new TerminalRepository(context);
            Signages = new SignageRepository(context);
            TerminalSignages = new TerminalSignageRepository(context);
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
