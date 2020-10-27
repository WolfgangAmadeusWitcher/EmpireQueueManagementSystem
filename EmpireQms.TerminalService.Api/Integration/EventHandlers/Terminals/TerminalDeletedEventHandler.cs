using EmpireQms.Domain.Core.Bus;
using EmpireQms.TerminalService.Api.Domain;
using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.TerminalService.Api.Integration.Events.Terminals;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.TerminalService.Api.Integration.EventHandlers.Terminals
{
    public class TerminalDeletedEventHandler : IEventHandler<TerminalDeletedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<TerminalHub> _hub;

        public TerminalDeletedEventHandler(IUnitOfWork unitOfWork, IHubContext<TerminalHub> terminalHub)
        {
            _unitOfWork = unitOfWork;
            _hub = terminalHub;
        }

        public Task Handle(TerminalDeletedEvent @event)
        {
            _unitOfWork.Terminals.Delete(@event.TerminalInstance);
            _hub.Clients.All.SendAsync("terminal-deleted-event", @event.TerminalInstance);
            return Task.CompletedTask;
        }
    }
}
