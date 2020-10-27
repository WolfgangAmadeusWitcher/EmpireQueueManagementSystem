using EmpireQms.Domain.Core.Bus;
using EmpireQms.SignageService.Api.Domain;
using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Integration.Events.Signages;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.SignageService.Api.Integration.EventHandlers.Signages
{
    public class SignageUpdatedEventHandler : IEventHandler<SignageUpdatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<SignageHub> _hub;

        public SignageUpdatedEventHandler(IUnitOfWork unitOfWork, IHubContext<SignageHub> signageHub)
        {
            _unitOfWork = unitOfWork;
            _hub = signageHub;
        }

        public Task Handle(SignageUpdatedEvent @event)
        {
            _unitOfWork.Signages.UpdateSignage(@event.SignageInstance);
            _hub.Clients.All.SendAsync("signage-updated-event", @event.SignageInstance);
            return Task.CompletedTask;
        }
    }
}
