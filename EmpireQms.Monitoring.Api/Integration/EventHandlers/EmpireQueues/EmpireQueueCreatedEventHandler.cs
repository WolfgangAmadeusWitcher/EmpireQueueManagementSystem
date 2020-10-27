using EmpireQms.Domain.Core.Bus;
using EmpireQms.Monitoring.Api.Domain;
using EmpireQms.Monitoring.Api.Domain.Models;
using EmpireQms.Monitoring.Api.Integration.Events.EmpireQueues;
using System.Threading.Tasks;

namespace EmpireQms.Monitoring.Api.Integration.EventHandlers.EmpireQueues
{
    public class EmpireQueueCreatedEventHandler : IEventHandler<EmpireQueueCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmpireQueueCreatedEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task Handle(EmpireQueueCreatedEvent @event)
        {
            var empireQueue = new EmpireQueue
            {
                Id = @event.EmpireQueue.Id,
                Name = @event.EmpireQueue.Name,
                QueueWeight = @event.EmpireQueue.QueueWeight,
                ActiveWaitersCount = @event.EmpireQueue.ActiveWaitersCount
            };

            _unitOfWork.EmpireQueues.Create(empireQueue);
            _unitOfWork.BroadcastServerEvent("empire-queue-created", empireQueue);
            return Task.CompletedTask;
        }
    }
}
