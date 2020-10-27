using EmpireQms.Domain.Core.Bus;
using EmpireQms.SignageService.Api.Domain;
using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Integration.Events.Terminals;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.SignageService.Api.Integration.EventHandlers.Terminals
{
    public class TerminalStateUpdatedEventHandler : IEventHandler<TerminalStateUpdatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<SignageHub> _hub;

        public TerminalStateUpdatedEventHandler(IUnitOfWork unitOfWork, IHubContext<SignageHub> signageHub)
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
