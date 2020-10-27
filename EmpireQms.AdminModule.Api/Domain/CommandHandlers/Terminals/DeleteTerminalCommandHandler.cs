using EmpireQms.AdminModule.Api.Domain.Commands;
using EmpireQms.AdminModule.Api.Domain.Events.Terminals;
using MediatR;
using EmpireQms.Domain.Core.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Domain.CommandHandlers.Terminals
{
    public class DeleteTerminalCommandHandler : IRequestHandler<DeleteTerminalCommand, bool>
    {
        private readonly IEventBus _bus;

        public DeleteTerminalCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(DeleteTerminalCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TerminalDeletedEvent(request.CommandedTerminal));
            return Task.FromResult(true);
        }
    }
}
