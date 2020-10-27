using EmpireQms.Domain.Core.Bus;
using EmpireQms.SignageService.Api.Domain;
using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Integration.Events.TerminalSignages;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.SignageService.Api.Integration.EventHandlers.TerminalSignages
{
    public class TerminalSignageCreatedEventHandler : IEventHandler<TerminalSignageCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<SignageHub> _hub;

        public TerminalSignageCreatedEventHandler(IUnitOfWork unitOfWork, IHubContext<SignageHub> signageHub)
        {
            _unitOfWork = unitOfWork;
            _hub = signageHub;
        }

        public Task Handle(TerminalSignageCreatedEvent @event)
        {
            _unitOfWork.TerminalSignages.Create(@event.TerminalSignage);
            _hub.Clients.All.SendAsync("terminal-signage-created-event", @event.TerminalSignage);
            return Task.CompletedTask;
        }
    }
}
