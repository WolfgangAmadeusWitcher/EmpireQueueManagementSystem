using EmpireQms.Domain.Core.Bus;
using EmpireQms.Monitoring.Api.Domain;
using EmpireQms.Monitoring.Api.Domain.Models;
using EmpireQms.Monitoring.Api.Integration.Events.Terminals;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.Monitoring.Api.Integration.EventHandlers.Terminals
{
    public class TerminalSettingsUpdatedEventHandler : IEventHandler<TerminalSettingsUpdatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<MonitoringHub> _hub;

        public TerminalSettingsUpdatedEventHandler(IUnitOfWork unitOfWork, IHubContext<MonitoringHub> terminalHub)
        {
            _unitOfWork = unitOfWork;
            _hub = terminalHub;
        }

        public Task Handle(TerminalSettingsUpdatedEvent @event)
        {
            var updatedTerminal = _unitOfWork.Terminals.Get(@event.TerminalSettingsUpdate.TerminalId);

            updatedTerminal.Alias = @event.TerminalSettingsUpdate.Alias;

            _unitOfWork.Terminals.UpdateTerminal(updatedTerminal);
            _hub.Clients.All.SendAsync("terminal-updated-event", updatedTerminal);
            return Task.CompletedTask;
        }
    }
}
