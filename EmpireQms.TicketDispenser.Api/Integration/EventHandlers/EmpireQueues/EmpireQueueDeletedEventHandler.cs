using EmpireQms.Domain.Core.Bus;
using EmpireQms.TicketDispenser.Api.Domain;
using EmpireQms.TicketDispenser.Api.Domain.Models;
using EmpireQms.TicketDispenser.Api.Integration.Events.EmpireQueues;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.TicketDispenser.Api.Integration.EventHandlers.EmpireQueues
{
    public class EmpireQueueDeletedEventHandler : IEventHandler<EmpireQueueDeletedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<TicketCategoryHub> _hub;

        public EmpireQueueDeletedEventHandler(IUnitOfWork unitOfWork, IHubContext<TicketCategoryHub> ticketCategoryHub)
        {
            _unitOfWork = unitOfWork;
            _hub = ticketCategoryHub;
        }

        public Task Handle(EmpireQueueDeletedEvent @event)
        {
            var deletedEmpireQueue = _unitOfWork.EmpireQueues.Get(@event.EmpireQueue.Id);
            _unitOfWork.EmpireQueues.Delete(deletedEmpireQueue);
            return Task.CompletedTask;
        }
    }
}
