using EmpireQms.Domain.Core.Bus;
using EmpireQms.TicketDispenser.Api.Domain;
using EmpireQms.TicketDispenser.Api.Domain.Models;
using EmpireQms.TicketDispenser.Api.Integration.Events.EmpireQueues;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.TicketDispenser.Api.Integration.EventHandlers.EmpireQueues
{
    public class EmpireQueueCreatedEventHandler : IEventHandler<EmpireQueueCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<TicketCategoryHub> _hub;

        public EmpireQueueCreatedEventHandler(IUnitOfWork unitOfWork, IHubContext<TicketCategoryHub> ticketCategoryHub)
        {
            _unitOfWork = unitOfWork;
            _hub = ticketCategoryHub;
        }

        public Task Handle(EmpireQueueCreatedEvent @event)
        {
            var empireQueue = new EmpireQueue
            {
                Id = @event.EmpireQueue.Id,
                TicketCategoryId = @event.EmpireQueue.TicketCategoryId
            };

            _unitOfWork.EmpireQueues.Create(empireQueue);
            return Task.CompletedTask;
        }
    }
}
