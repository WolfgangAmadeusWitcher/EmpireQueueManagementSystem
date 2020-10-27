using EmpireQms.Domain.Core.Bus;
using EmpireQms.Monitoring.Api.Domain;
using EmpireQms.Monitoring.Api.Domain.Models;
using EmpireQms.Monitoring.Api.Integration.Events.Terminals;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.Monitoring.Api.Integration.EventHandlers.Terminals
{
    public class TerminalDeletedEventHandler : IEventHandler<TerminalDeletedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<MonitoringHub> _hub;

        public TerminalDeletedEventHandler(IUnitOfWork unitOfWork, IHubContext<MonitoringHub> terminalHub)
        {
            _unitOfWork = unitOfWork;
            _hub = terminalHub;
        }

        public Task Handle(TerminalDeletedEvent @event)
        {
            _unitOfWork.Terminals.Delete(@event.TerminalInstance);
            _hub.Clients.All.SendAsync("terminal-deleted-event", @event.TerminalInstance.Id);
            return Task.CompletedTask;
        }
    }
}
