using EmpireQms.Domain.Core.Bus;
using EmpireQms.SignageService.Api.Domain;
using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Integration.Events.Signages;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.SignageService.Api.Integration.EventHandlers.Signages
{
    public class SignagesSyncedEventHandler : IEventHandler<SignagesSyncedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<SignageHub> _hub;

        public SignagesSyncedEventHandler(IUnitOfWork unitOfWork, IHubContext<SignageHub> signageHub)
        {
            _unitOfWork = unitOfWork;
            _hub = signageHub;
        }

        public Task Handle(SignagesSyncedEvent @event)
        {
            _unitOfWork.Signages.DeleteTable();
            _unitOfWork.Signages.CreateRange(@event.SignageTable);
            return Task.CompletedTask;
        }
    }
}
