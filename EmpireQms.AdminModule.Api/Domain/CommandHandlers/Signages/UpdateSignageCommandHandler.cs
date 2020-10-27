using EmpireQms.AdminModule.Api.Domain.Commands.Signages;
using EmpireQms.AdminModule.Api.Integration.Events.Signages;
using EmpireQms.Domain.Core.Bus;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Domain.CommandHandlers.Signages
{
    public class UpdateSignageCommandHandler : IRequestHandler<UpdateSignageCommand, bool>
    {
        private readonly IEventBus _bus;

        public UpdateSignageCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(UpdateSignageCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new SignageUpdatedEvent(request.Signage));
            return Task.FromResult(true);
        }
    }
}
