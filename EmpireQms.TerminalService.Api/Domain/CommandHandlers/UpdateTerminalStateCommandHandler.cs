using EmpireQms.Domain.Core.Bus;
using EmpireQms.TerminalService.Api.Domain.Commands;
using EmpireQms.TerminalService.Api.Integration.Events.Terminals;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.TerminalService.Api.Domain.CommandHandlers
{
    public class UpdateTerminalStateCommandHandler : IRequestHandler<UpdateTerminalStateCommand, bool>
    {
        private readonly IEventBus _bus;
        public UpdateTerminalStateCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(UpdateTerminalStateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TerminalStateUpdatedEvent(request.TerminalInstance));
            return Task.FromResult(true);
        }
    }
}
