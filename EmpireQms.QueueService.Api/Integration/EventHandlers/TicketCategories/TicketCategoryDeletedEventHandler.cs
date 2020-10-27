using EmpireQms.Domain.Core.Bus;
using EmpireQms.QueueService.Api.Domain;
using EmpireQms.QueueService.Api.Domain.Commands.EmpireQueues;
using EmpireQms.QueueService.Api.Integration.Events.TicketCategories;
using System.Threading.Tasks;

namespace EmpireQms.QueueService.Api.Integration.EventHandlers.TicketCategories
{
    public class TicketCategoryDeletedEventHandler : IEventHandler<TicketCategoryDeletedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketCategoryDeletedEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(TicketCategoryDeletedEvent @event)
        {
            _unitOfWork.TicketCategories.Delete(@event.TicketCategory);

            var deleteEmpireQueueCommand = new DeleteEmpireQueueCommand(@event.TicketCategory);
            _unitOfWork.SourceEvent(deleteEmpireQueueCommand);

            return Task.CompletedTask;
        }
    }
}
