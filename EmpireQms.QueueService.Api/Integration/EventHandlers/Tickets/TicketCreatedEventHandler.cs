using EmpireQms.Domain.Core.Bus;
using EmpireQms.QueueService.Api.Domain;
using EmpireQms.QueueService.Api.Domain.Commands.EmpireQueues;
using EmpireQms.QueueService.Api.Domain.Models;
using EmpireQms.QueueService.Api.Integration.Events.Tickets;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireQms.QueueService.Api.Integration.EventHandlers.Tickets
{
    public class TicketCreatedEventHandler : IEventHandler<TicketCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketCreatedEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(TicketCreatedEvent @event)
        {
            var createdTicket = new Ticket
            {
                Id = @event.Ticket.Id,
                Number = @event.Ticket.Number,
                CreatedDate = @event.Ticket.CreatedDate,
                TicketCategoryId = @event.Ticket.TicketCategoryId,
                TicketStatus = @event.Ticket.TicketStatus
            };

            var ticketQueue = _unitOfWork.EmpireQueues.Find(q => q.TicketCategoryId == createdTicket.TicketCategoryId).Single();
            createdTicket.QueueId = ticketQueue.Id;

            _unitOfWork.Tickets.Create(createdTicket);
            ++ticketQueue.ActiveWaitersCount;
            _unitOfWork.EmpireQueues.UpdateQueue(ticketQueue);
            var updateEmpireQueueCommand = new UpdateEmpireQueueCommand(ticketQueue);
            _unitOfWork.SourceEvent(updateEmpireQueueCommand);
            _unitOfWork.BroadcastServerEvent("empire-queue-updated-event", ticketQueue);

            return Task.CompletedTask;
        }
    }
}
