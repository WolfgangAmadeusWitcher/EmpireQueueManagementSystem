using EmpireQms.Domain.Core.Bus;
using EmpireQms.SignageService.Api.Domain;
using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Integration.Events.TerminalSignages;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.SignageService.Api.Integration.EventHandlers.TerminalSignages
{
    public class TerminalSignageDeletedEventHandler : IEventHandler<TerminalSignageDeletedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<SignageHub> _hub;

        public TerminalSignageDeletedEventHandler(IUnitOfWork unitOfWork, IHubContext<SignageHub> signageHub)
        {
            _unitOfWork = unitOfWork;
            _hub = signageHub;
        }

        public Task Handle(TerminalSignageDeletedEvent @event)
        {
            _unitOfWork.TerminalSignages.Delete(@event.TerminalSignage);
            _hub.Clients.All.SendAsync("terminal-signage-deleted-event", @event.TerminalSignage);
            return Task.CompletedTask;
        }
    }
}
