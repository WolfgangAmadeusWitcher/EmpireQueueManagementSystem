using EmpireQms.Monitoring.Api.Domain.Repositories;
using EmpireQms.Domain.Core.Commands;
using System;

namespace EmpireQms.Monitoring.Api.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ITerminalRepository Terminals { get; }
        IBreakLogEntryRepository BreakLogEntries { get; }
        IEmpireQueueRepository EmpireQueues { get; }
        public void BroadcastServerEvent<T>(string eventCode, T eventModel) where T : class;
        public void SourceEvent<T>(T command) where T : Command;
        int Complete();
    }
}
