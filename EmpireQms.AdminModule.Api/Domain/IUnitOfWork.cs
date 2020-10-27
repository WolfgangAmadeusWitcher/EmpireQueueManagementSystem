using EmpireQms.AdminModule.Api.Domain.Repositories;
using EmpireQms.Domain.Core.Commands;
using System;

namespace EmpireQms.AdminModule.Api.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ITicketCategoryRepository TicketCategories { get; }
        ITerminalRepository Terminals { get; }
        ISignageRepository Signages { get; }
        public void SourceEvent<T>(T command) where T : Command;
        int Complete();
    }
}
