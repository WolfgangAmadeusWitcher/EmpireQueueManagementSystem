using EmpireQms.Domain.Core.Bus;
using EmpireQms.SignageService.Api.Domain;
using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Integration.Events.Tickets;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireQms.SignageService.Api.Integration.EventHandlers.Tickets
{
    public class NextPersonCalledEventHandler : IEventHandler<NextPersonCalledEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public NextPersonCalledEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(NextPersonCalledEvent @event)
        {
            var targetSignageIds = _unitOfWork.TerminalSignages.Find(ts => ts.TerminalId == @event.TerminalId).Select(s => s.SignageId).ToList();
            var targetSignages = _unitOfWork.Signages.Find(s => targetSignageIds.Contains(s.Id)).ToList();
            var updatedTerminal = _unitOfWork.Terminals.Get(@event.TerminalId);
            updatedTerminal.CalledTicketNumber = @event.TicketNumber;
            updatedTerminal.Status = TerminalStatus.Serving;
            _unitOfWork.Terminals.UpdateTerminal(updatedTerminal);
            _unitOfWork.BroadcastServerEvent("terminal-updated-event", updatedTerminal);

            return Task.CompletedTask;
        }
    }
}
