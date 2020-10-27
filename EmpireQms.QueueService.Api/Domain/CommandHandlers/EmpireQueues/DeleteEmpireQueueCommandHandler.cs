using EmpireQms.Domain.Core.Bus;
using EmpireQms.QueueService.Api.Domain.Commands.EmpireQueues;
using EmpireQms.QueueService.Api.Integration.Events.EmpireQueues;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.QueueService.Api.Domain.CommandHandlers.EmpireQueues
{
    public class DeleteEmpireQueueCommandHandler : IRequestHandler<DeleteEmpireQueueCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventBus _bus;
        public DeleteEmpireQueueCommandHandler(IUnitOfWork unitOfWork, IEventBus eventBus)
        {
            _unitOfWork = unitOfWork;
            _bus = eventBus;
        }
        public Task<bool> Handle(DeleteEmpireQueueCommand request, CancellationToken cancellationToken)
        {
            var ticketCategoryQueue = _unitOfWork.EmpireQueues.Find(q => q.TicketCategoryId == request.TicketCategory.Id).Single();
            _unitOfWork.EmpireQueues.Delete(ticketCategoryQueue);

            _bus.Publish(new EmpireQueueDeletedEvent(ticketCategoryQueue));
            return Task.FromResult(true);
        }
    }
}
