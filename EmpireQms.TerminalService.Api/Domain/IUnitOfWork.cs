using EmpireQms.TerminalService.Api.Domain.Repositories;
using EmpireQms.Domain.Core.Commands;
using System;

namespace EmpireQms.TerminalService.Api.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ITerminalRepository Terminals { get; }
        IBreakLogEntryRepository BreakLogEntries { get; }
        ITicketCategoryRepository TicketCategories { get; }
        ITerminalCategoryRepository TerminalCategories { get; }
        public void SourceEvent<T>(T command) where T : Command;
        public void BroadcastServerEvent<T>(string eventCode, T eventModel) where T : class;
        int Complete();
    }
}
