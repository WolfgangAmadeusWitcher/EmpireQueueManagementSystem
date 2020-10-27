using EmpireQms.Domain.Core.Bus;
using EmpireQms.TicketDispenser.Api.Domain;
using EmpireQms.TicketDispenser.Api.Domain.Models;
using EmpireQms.TicketDispenser.Api.Integration.Events.TicketCategories;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.TicketDispenser.Api.Integration.EventHandlers.TicketCategories
{
    public class TicketCategoryUpdatedEventHandler : IEventHandler<TicketCategoryUpdatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<TicketCategoryHub> _hub;

        public TicketCategoryUpdatedEventHandler(IUnitOfWork unitOfWork, IHubContext<TicketCategoryHub> ticketCategoryHub)
        {
            _unitOfWork = unitOfWork;
            _hub = ticketCategoryHub;
        }

        public Task Handle(TicketCategoryUpdatedEvent @event)
        {
            var updatedTicketCategory = new TicketCategory
            {
                Id = @event.TicketCategory.Id,
                Name = @event.TicketCategory.Name,
                Description = @event.TicketCategory.Description,
                FirstTicketNumber = @event.TicketCategory.FirstTicketNumber,
                LastTicketNumber = @event.TicketCategory.LastTicketNumber
            };

            _unitOfWork.TicketCategories.UpdateCategory(updatedTicketCategory);
            _hub.Clients.All.SendAsync("ticket-category-updated-event", updatedTicketCategory);
            return Task.CompletedTask;
        }
    }
}
