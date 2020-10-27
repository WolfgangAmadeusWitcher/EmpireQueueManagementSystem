using EmpireQms.Domain.Core.Bus;
using EmpireQms.SignageService.Api.Domain;
using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Integration.Events.Terminals;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.SignageService.Api.Integration.EventHandlers.Terminals
{
    public class TerminalCreatedEventHandler : IEventHandler<TerminalCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<SignageHub> _hub;

        public TerminalCreatedEventHandler(IUnitOfWork unitOfWork, IHubContext<SignageHub> signageHub)
        {
            _unitOfWork = unitOfWork;
            _hub = signageHub;
        }

        public Task Handle(TerminalCreatedEvent @event)
        {
            var createdTerminal = new Terminal
            {
                Id = @event.TerminalInstance.Id,
                Alias = @event.TerminalInstance.Alias,
                Status = @event.TerminalInstance.Status
            };

            createdTerminal.Status = TerminalStatus.Offline;
            _unitOfWork.Terminals.Create(createdTerminal);
            return Task.CompletedTask;
        }
    }
}
