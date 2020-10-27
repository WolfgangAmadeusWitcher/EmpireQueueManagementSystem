using EmpireQms.Domain.Core.Bus;
using EmpireQms.Monitoring.Api.Domain;
using EmpireQms.Monitoring.Api.Domain.Models;
using EmpireQms.Monitoring.Api.Integration.Events.Terminals;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.Monitoring.Api.Integration.EventHandlers.Terminals
{
    public class TerminalStateUpdatedEventHandler : IEventHandler<TerminalStateUpdatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<MonitoringHub> _hub;

        public TerminalStateUpdatedEventHandler(IUnitOfWork unitOfWork, IHubContext<MonitoringHub> signageHub)
        {
            _unitOfWork = unitOfWork;
            _hub = signageHub;
        }

        public Task Handle(TerminalStateUpdatedEvent @event)
        {
            var updatedTerminal = _unitOfWork.Terminals.Get(@event.TerminalInstance.Id);
            updatedTerminal.Status = @event.TerminalInstance.Status;

            _unitOfWork.Terminals.UpdateTerminal(updatedTerminal);
            _hub.Clients.All.SendAsync("terminal-updated-event", updatedTerminal);
            return Task.CompletedTask;
        }
    }
}
