using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.Domain.Core.Bus;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using EmpireQms.TerminalService.Api.Domain;
using EmpireQms.TerminalService.Api.Integration.Events.TerminalCategories;

namespace EmpireQms.TerminalService.Api.Integration.EventHandlers.TerminalCategories
{
    public class TerminalCategoryCreatedEventHandler : IEventHandler<TerminalCategoryCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<TerminalHub> _hub;

        public TerminalCategoryCreatedEventHandler(IUnitOfWork unitOfWork, IHubContext<TerminalHub> terminalHub)
        {
            _unitOfWork = unitOfWork;
            _hub = terminalHub;
        }

        public Task Handle(TerminalCategoryCreatedEvent @event)
        {
            var createdTerminalCategory = new TerminalCategory
            {
                TerminalId = @event.TerminalCategory.TerminalId,
                TicketCategoryId = @event.TerminalCategory.TicketCategoryId,
            };

            _unitOfWork.TerminalCategories.Create(createdTerminalCategory);
            _hub.Clients.All.SendAsync("terminal-category-created-event", createdTerminalCategory);
            return Task.CompletedTask;
        }
    }
}
