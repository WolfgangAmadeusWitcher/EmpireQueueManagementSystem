using EmpireQms.Domain.Core.Bus;
using EmpireQms.Domain.Core.Commands;
using EmpireQms.QueueService.Api.Domain;
using EmpireQms.QueueService.Api.Domain.Models;
using EmpireQms.QueueService.Api.Domain.Repositories;
using EmpireQms.QueueService.Api.Persistence.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace EmpireQms.QueueService.Api.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QueueContext _context;
        private readonly IEventBus _eventBus;
        private readonly IHubContext<EmpireQueueHub> _hub;

        public ITerminalTicketRepository TerminalTickets { get; private set; }
        public IQueueRepository EmpireQueues { get; private set; }
        public ITicketRepository Tickets { get; private set; }
        public ITicketCategoryRepository TicketCategories { get; private set; }
        public ITerminalCategoryRepository TerminalCategories { get; private set; }
        public ITerminalRepository Terminals { get; private set; }

        public UnitOfWork(QueueContext context, IEventBus eventBus, IHubContext<EmpireQueueHub> empireQueueHub)
        {
            _hub = empireQueueHub;
            _context = context;
            _eventBus = eventBus;
            EmpireQueues = new QueueRepository(context);
            Tickets = new TicketRepository(context);
            TicketCategories = new TicketCategoryRepository(context);
            TerminalCategories = new TerminalCategoryRepository(context);
            TerminalTickets = new TerminalTicketRepository(context);
            Terminals = new TerminalRepository(context);
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

        public void BroadcastServerEvent<T>(string eventCode, T eventModel) where T : class
        {
            _hub.Clients.All.SendAsync(eventCode, eventModel);
        }
    }
}
