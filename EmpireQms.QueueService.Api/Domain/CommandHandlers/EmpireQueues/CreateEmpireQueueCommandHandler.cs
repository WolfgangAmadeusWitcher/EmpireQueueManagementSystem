using EmpireQms.Domain.Core.Bus;
using EmpireQms.QueueService.Api.Domain.Commands.EmpireQueues;
using EmpireQms.QueueService.Api.Domain.Models;
using EmpireQms.QueueService.Api.Integration.Events.EmpireQueues;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.QueueService.Api.Domain.CommandHandlers.EmpireQueues
{
    public class CreateEmpireQueueCommandHandler : IRequestHandler<CreateEmpireQueueCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventBus _bus;
        public CreateEmpireQueueCommandHandler(IUnitOfWork unitOfWork, IEventBus eventBus)
        {
            _unitOfWork = unitOfWork;
            _bus = eventBus;
        }

        public Task<bool> Handle(CreateEmpireQueueCommand request, CancellationToken cancellationToken)
        {
            var empireQueue = new EmpireQueue
            {
                TicketCategoryId = request.TicketCategory.Id,
                QueueWeight = request.TicketCategory.PriorityCoefficient,
                ActiveWaitersCount = 0,
                Name = request.TicketCategory.Name
            };
            _unitOfWork.EmpireQueues.Create(empireQueue);
            _bus.Publish(new EmpireQueueCreatedEvent(empireQueue));
            return Task.FromResult(true);
        }
    }
}
