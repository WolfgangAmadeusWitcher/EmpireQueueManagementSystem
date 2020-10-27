using EmpireQms.Domain.Core.Bus;
using EmpireQms.QueueService.Api.Domain;
using EmpireQms.QueueService.Api.Integration.Events.Terminals;
using System.Threading.Tasks;

namespace EmpireQms.QueueService.Api.Integration.EventHandlers.Terminals
{
    public class TerminalDeletedEventHandler : IEventHandler<TerminalDeletedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TerminalDeletedEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(TerminalDeletedEvent @event)
        {
            _unitOfWork.Terminals.Delete(@event.TerminalInstance);
            return Task.CompletedTask;
        }
    }
}
