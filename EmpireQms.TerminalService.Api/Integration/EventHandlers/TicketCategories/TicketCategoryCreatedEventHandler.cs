using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.Domain.Core.Bus;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using EmpireQms.TerminalService.Api.Domain;
using EmpireQms.TerminalService.Api.Integration.Events.TicketCategories;

namespace EmpireQms.TerminalService.Api.Integration.EventHandlers.TicketCategories
{
    public class TicketCategoryCreatedEventHandler : IEventHandler<TicketCategoryCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<TerminalHub> _hub;

        public TicketCategoryCreatedEventHandler(IUnitOfWork unitOfWork, IHubContext<TerminalHub> ticketCategoryHub)
        {
            _unitOfWork = unitOfWork;
            _hub = ticketCategoryHub;
        }

        public Task Handle(TicketCategoryCreatedEvent @event)
        {
            var createdTicketCategory = new TicketCategory
            {
                Id = @event.TicketCategory.Id,
                Name = @event.TicketCategory.Name,
                PriorityCoefficient = @event.TicketCategory.PriorityCoefficient
            };

            _unitOfWork.TicketCategories.Create(createdTicketCategory);
            _hub.Clients.All.SendAsync("ticket-category-created-event", createdTicketCategory);
            return Task.CompletedTask;
        }
    }
}
