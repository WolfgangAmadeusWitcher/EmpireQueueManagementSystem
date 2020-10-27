using EmpireQms.AdminModule.Api.Domain.Commands.Signages;
using EmpireQms.AdminModule.Api.Integration.Events.Signages;
using EmpireQms.Domain.Core.Bus;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Domain.CommandHandlers.Signages
{
    public class CreateSignageCommandHandler : IRequestHandler<CreateSignageCommand, bool>
    {
        private readonly IEventBus _bus;

        public CreateSignageCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(CreateSignageCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new SignageCreatedEvent(request.Signage));
            return Task.FromResult(true);
        }
    }
}
