using EmpireQms.Domain.Core.Bus;
using EmpireQms.QueueService.Api.Domain;
using EmpireQms.QueueService.Api.Domain.Models;
using EmpireQms.QueueService.Api.Integration.Events.Terminals;
using System.Threading.Tasks;

namespace EmpireQms.QueueService.Api.Integration.EventHandlers.Terminals
{
    public class TerminalCreatedEventHandler : IEventHandler<TerminalCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TerminalCreatedEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(TerminalCreatedEvent @event)
        {
            var createdTerminal = new Terminal
            {
                Id = @event.TerminalInstance.Id,
            };

            _unitOfWork.Terminals.Create(createdTerminal);
            return Task.CompletedTask;
        }
    }
}
