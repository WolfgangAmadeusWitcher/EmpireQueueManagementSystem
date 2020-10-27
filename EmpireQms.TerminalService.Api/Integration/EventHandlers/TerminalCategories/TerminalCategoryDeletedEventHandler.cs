using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.Domain.Core.Bus;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using EmpireQms.TerminalService.Api.Domain;
using EmpireQms.TerminalService.Api.Integration.Events.TerminalCategories;

namespace EmpireQms.TerminalService.Api.Integration.EventHandlers.TerminalCategories
{
    public class TerminalCategoryDeletedEventHandler : IEventHandler<TerminalCategoryDeletedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<TerminalHub> _hub;

        public TerminalCategoryDeletedEventHandler(IUnitOfWork unitOfWork, IHubContext<TerminalHub> terminalHub)
        {
            _unitOfWork = unitOfWork;
            _hub = terminalHub;
        }

        public Task Handle(TerminalCategoryDeletedEvent @event)
        {
            _unitOfWork.TerminalCategories.Delete(@event.TerminalCategory);
            _hub.Clients.All.SendAsync("terminal-category-deleted-event", @event.TerminalCategory);
            return Task.CompletedTask;
        }
    }
}
