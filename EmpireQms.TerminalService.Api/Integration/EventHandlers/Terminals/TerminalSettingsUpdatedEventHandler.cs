using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.Domain.Core.Bus;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using EmpireQms.TerminalService.Api.Domain;
using EmpireQms.TerminalService.Api.Integration.Events.Terminals;

namespace EmpireQms.TerminalService.Api.Integration.EventHandlers.Terminals
{
    public class TerminalSettingsUpdatedEventHandler : IEventHandler<TerminalSettingsUpdatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<TerminalHub> _hub;

        public TerminalSettingsUpdatedEventHandler(IUnitOfWork unitOfWork, IHubContext<TerminalHub> terminalHub)
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
