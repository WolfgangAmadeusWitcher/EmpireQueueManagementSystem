using EmpireQms.Domain.Core.Commands;
using EmpireQms.QueueService.Api.Domain.Repositories;
using System;

namespace EmpireQms.QueueService.Api.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ITerminalTicketRepository TerminalTickets { get; }
        IQueueRepository EmpireQueues { get; }
        ITicketRepository Tickets { get; }
        ITicketCategoryRepository TicketCategories { get; }
        ITerminalCategoryRepository TerminalCategories { get; }
        ITerminalRepository Terminals { get; }
        public void SourceEvent<T>(T command) where T : Command;
        public void BroadcastServerEvent<T>(string eventCode, T eventModel) where T : class;
        int Complete();
    }
}
