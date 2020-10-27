using EmpireQms.Domain.Core.Bus;
using EmpireQms.SignageService.Api.Domain;
using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Integration.Events.Terminals;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.SignageService.Api.Integration.EventHandlers.Terminals
{
    public class TerminalsSyncedEventHandler : IEventHandler<TerminalsSyncedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<SignageHub> _hub;

        public TerminalsSyncedEventHandler(IUnitOfWork unitOfWork, IHubContext<SignageHub> signageHub)
        {
            _unitOfWork = unitOfWork;
            _hub = signageHub;
        }

        public Task Handle(TerminalsSyncedEvent @event)
        {
            _unitOfWork.Terminals.DeleteTable();
            _unitOfWork.Terminals.CreateRange(@event.TerminalsTable);
            return Task.CompletedTask;
        }
    }
}
