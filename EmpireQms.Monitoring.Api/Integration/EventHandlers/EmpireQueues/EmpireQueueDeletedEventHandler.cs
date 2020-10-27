using EmpireQms.Domain.Core.Bus;
using EmpireQms.Monitoring.Api.Domain;
using EmpireQms.Monitoring.Api.Integration.Events.EmpireQueues;
using System.Threading.Tasks;

namespace EmpireQms.Monitoring.Api.Integration.EventHandlers.EmpireQueues
{
    public class EmpireQueueDeletedEventHandler : IEventHandler<EmpireQueueDeletedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmpireQueueDeletedEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task Handle(EmpireQueueDeletedEvent @event)
        {
            _unitOfWork.EmpireQueues.Delete(@event.EmpireQueue);
            _unitOfWork.BroadcastServerEvent("empire-queue-deleted", @event.EmpireQueue);
            return Task.CompletedTask;
        }
    }
}
