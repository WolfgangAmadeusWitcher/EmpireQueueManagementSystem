using EmpireQms.Domain.Core.Bus;
using EmpireQms.TicketDispenser.Api.Domain;
using EmpireQms.TicketDispenser.Api.Domain.Models;
using EmpireQms.TicketDispenser.Api.Integration.Events.TicketCategories;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.TicketDispenser.Api.Integration.EventHandlers.TicketCategories
{
    public class TicketCategoryDeletedEventHandler : IEventHandler<TicketCategoryDeletedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<TicketCategoryHub> _hub;

        public TicketCategoryDeletedEventHandler(IUnitOfWork unitOfWork, IHubContext<TicketCategoryHub> ticketCategoryHub)
        {
            _unitOfWork = unitOfWork;
            _hub = ticketCategoryHub;
        }

        public Task Handle(TicketCategoryDeletedEvent @event)
        {
            _unitOfWork.TicketCategories.Delete(@event.TicketCategory);
            _hub.Clients.All.SendAsync("ticket-category-deleted-event", @event.TicketCategory);
            return Task.CompletedTask;
        }
    }
}
