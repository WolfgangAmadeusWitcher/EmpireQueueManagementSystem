using EmpireQms.Domain.Core.Bus;
using EmpireQms.SignageService.Api.Domain;
using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Integration.Events.Signages;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.SignageService.Api.Integration.EventHandlers.Signages
{
    public class SignageDeletedEventHandler : IEventHandler<SignageDeletedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<SignageHub> _hub;

        public SignageDeletedEventHandler(IUnitOfWork unitOfWork, IHubContext<SignageHub> signageHub)
        {
            _unitOfWork = unitOfWork;
            _hub = signageHub;
        }

        public Task Handle(SignageDeletedEvent @event)
        {
            _unitOfWork.Signages.Delete(@event.SignageInstance);
            _hub.Clients.All.SendAsync("signage-deleted-event", @event.SignageInstance.Id);
            return Task.CompletedTask;
        }
    }
}
