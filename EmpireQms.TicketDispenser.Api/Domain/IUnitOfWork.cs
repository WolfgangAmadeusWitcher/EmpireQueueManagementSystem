using EmpireQms.Domain.Core.Commands;
using EmpireQms.TicketDispenser.Api.Domain.Repositories;
using System;

namespace EmpireQms.TicketDispenser.Api.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IEmpireQueueRepository EmpireQueues { get; }
        ITicketCategoryRepository TicketCategories { get; }
        ITicketRepository Tickets { get; }
        public void SourceEvent<T>(T command) where T : Command;
        int Complete();
    }
}
