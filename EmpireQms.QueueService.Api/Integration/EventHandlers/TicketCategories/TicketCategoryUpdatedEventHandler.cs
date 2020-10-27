using EmpireQms.Domain.Core.Bus;
using EmpireQms.QueueService.Api.Domain;
using EmpireQms.QueueService.Api.Domain.Commands.EmpireQueues;
using EmpireQms.QueueService.Api.Domain.Models;
using EmpireQms.QueueService.Api.Integration.Events.TicketCategories;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireQms.QueueService.Api.Integration.EventHandlers.TicketCategories
{
    public class TicketCategoryUpdatedEventHandler : IEventHandler<TicketCategoryUpdatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketCategoryUpdatedEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(TicketCategoryUpdatedEvent @event)
        {
            var updatedTicketCategory = new TicketCategory
            {
                Id = @event.TicketCategory.Id,
                PriorityCoefficient = @event.TicketCategory.PriorityCoefficient,
                Name = @event.TicketCategory.Name
            };
            _unitOfWork.TicketCategories.UpdateTicketCategory(updatedTicketCategory);

            var selectedQueue = _unitOfWork.EmpireQueues.Find(eq => eq.TicketCategoryId == @event.TicketCategory.Id).SingleOrDefault();
            if(selectedQueue == null) return Task.CompletedTask;

            selectedQueue.QueueWeight = @event.TicketCategory.PriorityCoefficient;
            selectedQueue.Name = @event.TicketCategory.Name;
            _unitOfWork.EmpireQueues.UpdateQueue(selectedQueue);
            UpdateEmpireQueueCommand updateEmpireQueueCommand = new UpdateEmpireQueueCommand(selectedQueue);
            _unitOfWork.SourceEvent(updateEmpireQueueCommand);
            return Task.CompletedTask;
        }
    }
}
