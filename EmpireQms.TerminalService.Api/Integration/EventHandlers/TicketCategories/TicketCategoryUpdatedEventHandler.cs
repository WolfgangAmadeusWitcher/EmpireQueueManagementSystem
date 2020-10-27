using EmpireQms.Domain.Core.Bus;
using EmpireQms.TerminalService.Api.Domain;
using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.TerminalService.Api.Integration.Events.TicketCategories;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.TerminalService.Api.Integration.EventHandlers.TicketCategories
{
    public class TicketCategoryUpdatedEventHandler : IEventHandler<TicketCategoryUpdatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<TerminalHub> _hub;

        public TicketCategoryUpdatedEventHandler(IUnitOfWork unitOfWork, IHubContext<TerminalHub> terminalHub)
        {
            _unitOfWork = unitOfWork;
            _hub = terminalHub;
        }

        public Task Handle(TicketCategoryUpdatedEvent @event)
        {
            var updatedTicketCategory = new TicketCategory
            {
                Id = @event.TicketCategory.Id,
                Name = @event.TicketCategory.Name,
                PriorityCoefficient = @event.TicketCategory.PriorityCoefficient,
            };

            _unitOfWork.TicketCategories.UpdateTicketCategory(updatedTicketCategory);
            _hub.Clients.All.SendAsync("ticket-category-updated-event", updatedTicketCategory);
            return Task.CompletedTask;
        }
    }
}