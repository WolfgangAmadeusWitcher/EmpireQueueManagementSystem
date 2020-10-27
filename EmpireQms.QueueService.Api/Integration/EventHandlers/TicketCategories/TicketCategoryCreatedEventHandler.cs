using EmpireQms.Domain.Core.Bus;
using EmpireQms.QueueService.Api.Domain;
using EmpireQms.QueueService.Api.Domain.Commands.EmpireQueues;
using EmpireQms.QueueService.Api.Domain.Models;
using EmpireQms.QueueService.Api.Integration.Events.TicketCategories;
using System.Threading.Tasks;

namespace EmpireQms.QueueService.Api.Integration.EventHandlers.TicketCategories
{
    public class TicketCategoryCreatedEventHandler : IEventHandler<TicketCategoryCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketCategoryCreatedEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(TicketCategoryCreatedEvent @event)
        {
            var createdTicketCategory = new TicketCategory
            {
                Id = @event.TicketCategory.Id,
                Name = @event.TicketCategory.Name,
                PriorityCoefficient = @event.TicketCategory.PriorityCoefficient
            };

            _unitOfWork.TicketCategories.Create(createdTicketCategory);

            var createEmpireQueueCommand = new CreateEmpireQueueCommand(createdTicketCategory);
            _unitOfWork.SourceEvent(createEmpireQueueCommand);
            return Task.CompletedTask;
        }
    }
}
