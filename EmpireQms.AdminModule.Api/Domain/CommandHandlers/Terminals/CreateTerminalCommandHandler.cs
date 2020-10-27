using EmpireQms.AdminModule.Api.Domain.Commands;
using EmpireQms.AdminModule.Api.Domain.Events.Terminals;
using MediatR;
using EmpireQms.Domain.Core.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Domain.CommandHandlers.Terminals
{
    public class CreateTerminalCommandHandler : IRequestHandler<CreateTerminalCommand, bool>
    {
        private readonly IEventBus _bus;

        public CreateTerminalCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(CreateTerminalCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TerminalCreatedEvent(request.CommandedTerminal));
            return Task.FromResult(true);
        }
    }
}
