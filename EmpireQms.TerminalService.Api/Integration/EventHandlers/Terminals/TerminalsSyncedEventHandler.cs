using EmpireQms.Domain.Core.Bus;
using EmpireQms.TerminalService.Api.Domain;
using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.TerminalService.Api.Integration.Events.Terminals;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.TerminalService.Api.Integration.EventHandlers.Terminals
{
    public class TerminalsSyncedEventHandler : IEventHandler<TerminalsSyncedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<TerminalHub> _hub;

        public TerminalsSyncedEventHandler(IUnitOfWork unitOfWork, IHubContext<TerminalHub> signageHub)
        {
            _unitOfWork = unitOfWork;
            _hub = signageHub;
        }

        public Task Handle(TerminalsSyncedEvent @event)
        {
            _unitOfWork.Terminals.DeleteTable();
            _unitOfWork.Terminals.CreateRange(@event.TerminalsTable);
            return Task.CompletedTask;
        }
    }
}
