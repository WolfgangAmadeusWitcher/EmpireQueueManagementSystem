using EmpireQms.Domain.Core.Bus;
using EmpireQms.SignageService.Api.Domain;
using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Integration.Events.Signages;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.SignageService.Api.Integration.EventHandlers.Signages
{
    public class SignageCreatedEventHandler : IEventHandler<SignageCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<SignageHub> _hub;

        public SignageCreatedEventHandler(IUnitOfWork unitOfWork, IHubContext<SignageHub> signageHub)
        {
            _unitOfWork = unitOfWork;
            _hub = signageHub;
        }

        public Task Handle(SignageCreatedEvent @event)
        {
            _unitOfWork.Signages.Create(@event.Signage);
            _hub.Clients.All.SendAsync("signage-created-event", @event.Signage);
            return Task.CompletedTask;
        }
    }
}
