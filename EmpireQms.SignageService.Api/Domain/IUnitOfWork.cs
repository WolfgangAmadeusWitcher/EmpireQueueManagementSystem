using EmpireQms.Domain.Core.Commands;
using EmpireQms.SignageService.Api.Domain.Repositories;
using System;

namespace EmpireQms.SignageService.Api.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ITerminalRepository Terminals { get; }
        ISignageRepository Signages { get; }
        ITerminalSignageRepository TerminalSignages { get; }
        public void SourceEvent<T>(T command) where T : Command;
        public void BroadcastServerEvent<T>(string eventCode, T eventModel) where T : class;
        int Complete();
    }
}
