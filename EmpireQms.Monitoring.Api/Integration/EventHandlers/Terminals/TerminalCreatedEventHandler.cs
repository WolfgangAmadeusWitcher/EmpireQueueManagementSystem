using EmpireQms.Domain.Core.Bus;
using EmpireQms.Monitoring.Api.Domain;
using EmpireQms.Monitoring.Api.Domain.Models;
using EmpireQms.Monitoring.Api.Integration.Events.Terminals;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.Monitoring.Api.Integration.EventHandlers.Terminals
{
    public class TerminalCreatedEventHandler : IEventHandler<TerminalCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<MonitoringHub> _hub;

        public TerminalCreatedEventHandler(IUnitOfWork unitOfWork, IHubContext<MonitoringHub> terminalHub)
        {
            _unitOfWork = unitOfWork;
            _hub = terminalHub;
        }

        public Task Handle(TerminalCreatedEvent @event)
        {
            var createdTerminal = new Terminal
            {
                Id = @event.TerminalInstance.Id,
                Alias = @event.TerminalInstance.Alias,
                Status = @event.TerminalInstance.Status
            };

            _unitOfWork.Terminals.Create(createdTerminal);
            _hub.Clients.All.SendAsync("terminal-created-event", createdTerminal);
            return Task.CompletedTask;
        }
    }
}
