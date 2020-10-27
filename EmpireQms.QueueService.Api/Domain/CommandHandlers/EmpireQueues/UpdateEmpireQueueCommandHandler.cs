using EmpireQms.Domain.Core.Bus;
using EmpireQms.QueueService.Api.Domain.Commands.EmpireQueues;
using EmpireQms.QueueService.Api.Integration.Events.EmpireQueues;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.QueueService.Api.Domain.CommandHandlers.EmpireQueues
{
    public class UpdateEmpireQueueCommandHandler : IRequestHandler<UpdateEmpireQueueCommand, bool>
    {
        private readonly IEventBus _bus;
        public UpdateEmpireQueueCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }
        public Task<bool> Handle(UpdateEmpireQueueCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new EmpireQueueUpdatedEvent(request.EmpireQueue));
            return Task.FromResult(true);
        }
    }
}
