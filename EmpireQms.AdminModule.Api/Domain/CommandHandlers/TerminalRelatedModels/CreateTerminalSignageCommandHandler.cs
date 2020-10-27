using EmpireQms.AdminModule.Api.Domain.Commands.TerminalRelatedObjects;
using EmpireQms.AdminModule.Api.Domain.Events.TerminalRelatedObjects;
using MediatR;
using EmpireQms.Domain.Core.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Domain.CommandHandlers.TerminalRelatedObjects
{
    public class CreateTerminalSignageCommandHandler : IRequestHandler<CreateTerminalSignageCommand, bool>
    {
        private readonly IEventBus _bus;

        public CreateTerminalSignageCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(CreateTerminalSignageCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TerminalSignageCreatedEvent(request.TerminalSignage));
            return Task.FromResult(true);
        }
    }
}
