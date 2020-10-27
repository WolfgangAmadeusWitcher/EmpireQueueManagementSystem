using EmpireQms.Domain.Core.Bus;
using EmpireQms.Domain.Core.Commands;
using EmpireQms.Monitoring.Api.Domain;
using EmpireQms.Monitoring.Api.Domain.Models;
using EmpireQms.Monitoring.Api.Domain.Repositories;
using EmpireQms.Monitoring.Api.Persistence.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace EmpireQms.Monitoring.Api.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MonitoringContext _context;
        private readonly IEventBus _eventBus;
        private readonly IHubContext<MonitoringHub> _hub;

        public ITerminalRepository Terminals { get; private set; }
        public IBreakLogEntryRepository BreakLogEntries { get; private set; }
        public IEmpireQueueRepository EmpireQueues { get; private set; }

        public UnitOfWork(MonitoringContext context, IEventBus eventBus, IHubContext<MonitoringHub> monitoringHub)
        {
            _hub = monitoringHub;
            _context = context;
            _eventBus = eventBus;
            Terminals = new TerminalRepository(context);
            BreakLogEntries = new BreakLogEntryRepository(context);
            EmpireQueues = new EmpireQueueRepository(context);
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
