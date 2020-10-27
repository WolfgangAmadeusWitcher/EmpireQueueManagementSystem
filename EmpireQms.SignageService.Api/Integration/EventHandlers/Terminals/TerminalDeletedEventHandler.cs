using EmpireQms.Domain.Core.Bus;
using EmpireQms.SignageService.Api.Domain;
using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Integration.Events.Terminals;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.SignageService.Api.Integration.EventHandlers.Terminals
{
    public class TerminalDeletedEventHandler : IEventHandler<TerminalDeletedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<SignageHub> _hub;

        public TerminalDeletedEventHandler(IUnitOfWork unitOfWork, IHubContext<SignageHub> signageHub)
        {
            _unitOfWork = unitOfWork;
            _hub = signageHub;
        }

        public Task Handle(TerminalDeletedEvent @event)
        {
            _unitOfWork.Terminals.Delete(@event.TerminalInstance);
            _hub.Clients.All.SendAsync("terminal-deleted-event", @event.TerminalInstance.Id);
            return Task.CompletedTask;
        }
    }
}
