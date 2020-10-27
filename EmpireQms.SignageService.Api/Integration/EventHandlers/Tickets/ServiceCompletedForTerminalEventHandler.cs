using EmpireQms.Domain.Core.Bus;
using EmpireQms.SignageService.Api.Domain;
using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Integration.Events.Tickets;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireQms.SignageService.Api.Integration.EventHandlers.Tickets
{
    public class ServiceCompletedForTerminalEventHandler : IEventHandler<ServiceCompletedForTerminalEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceCompletedForTerminalEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(ServiceCompletedForTerminalEvent @event)
        {
            var targetSignageIds = _unitOfWork.TerminalSignages.Find(ts => ts.TerminalId == @event.TerminalId).Select(s => s.SignageId).ToList();
            var targetSignages = _unitOfWork.Signages.Find(s => targetSignageIds.Contains(s.Id)).ToList();
            var updatedTerminal = _unitOfWork.Terminals.Get(@event.TerminalId);
            updatedTerminal.CalledTicketNumber = null;
            updatedTerminal.Status = TerminalStatus.Online;
            _unitOfWork.Terminals.UpdateTerminal(updatedTerminal);
            _unitOfWork.BroadcastServerEvent("terminal-updated-event", updatedTerminal);

            return Task.CompletedTask;
        }
    }
}
