using EmpireQms.Domain.Core.Bus;
using EmpireQms.TerminalService.Api.Domain.Commands;
using EmpireQms.TerminalService.Api.Integration.Events.BreakLogEntries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.TerminalService.Api.Domain.CommandHandlers
{
    public class UpdateBreakLogEntryCommandHandler : IRequestHandler<UpdateBreakLogEntryCommand, bool>
    {
        private readonly IEventBus _bus;
        public UpdateBreakLogEntryCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(UpdateBreakLogEntryCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new BreakLogEntryUpdatedEvent(request.BreakLogEntryInstance));
            return Task.FromResult(true);
        }
    }
}
