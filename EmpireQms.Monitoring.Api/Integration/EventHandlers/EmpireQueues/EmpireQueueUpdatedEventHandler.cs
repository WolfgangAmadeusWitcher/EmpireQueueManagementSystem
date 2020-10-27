using EmpireQms.Domain.Core.Bus;
using EmpireQms.Monitoring.Api.Domain;
using EmpireQms.Monitoring.Api.Integration.Events.EmpireQueues;
using System.Threading.Tasks;

namespace EmpireQms.Monitoring.Api.Integration.EventHandlers.EmpireQueues
{
    public class EmpireQueueUpdatedEventHandler : IEventHandler<EmpireQueueUpdatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmpireQueueUpdatedEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task Handle(EmpireQueueUpdatedEvent @event)
        { 
            _unitOfWork.EmpireQueues.UpdateEmpireQueue(@event.EmpireQueue);
            _unitOfWork.BroadcastServerEvent("empire-queue-updated", @event.EmpireQueue);
            return Task.CompletedTask;
        }
    }
}
