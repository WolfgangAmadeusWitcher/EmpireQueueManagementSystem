using EmpireQms.AdminModule.Api.Domain.Commands.Terminals;
using EmpireQms.AdminModule.Api.Domain.Events.Terminals;
using EmpireQms.Domain.Core.Bus;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Domain.CommandHandlers.Terminals
{
    public class SyncTerminalsCommandHandler : IRequestHandler<SyncTerminalsCommand, bool>
    {
        private readonly IEventBus _bus;

        public SyncTerminalsCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(SyncTerminalsCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TerminalsSyncedEvent(request.TerminalsTable));
            return Task.FromResult(true);
        }
    }
}
