using EmpireQms.Domain.Core.Bus;
using EmpireQms.TerminalService.Api.Domain;
using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.TerminalService.Api.Integration.Events.TicketCategories;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.TerminalService.Api.Integration.EventHandlers.TicketCategories
{
    public class TicketCategoryDeletedEventHandler : IEventHandler<TicketCategoryDeletedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<TerminalHub> _hub;

        public TicketCategoryDeletedEventHandler(IUnitOfWork unitOfWork, IHubContext<TerminalHub> terminalHub)
        {
            _unitOfWork = unitOfWork;
            _hub = terminalHub;
        }

        public Task Handle(TicketCategoryDeletedEvent @event)
        {
            _unitOfWork.TicketCategories.Delete(@event.TicketCategory);
            _hub.Clients.All.SendAsync("ticket-category-deleted-event", @event.TicketCategory);
            return Task.CompletedTask;
        }
    }
}
