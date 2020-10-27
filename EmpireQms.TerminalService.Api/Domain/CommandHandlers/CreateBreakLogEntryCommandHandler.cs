using EmpireQms.Domain.Core.Bus;
using EmpireQms.TerminalService.Api.Domain.Commands;
using EmpireQms.TerminalService.Api.Integration.Events.BreakLogEntries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.TerminalService.Api.Domain.CommandHandlers
{
    public class CreateBreakLogEntryCommandHandler : IRequestHandler<CreateBreakLogEntryCommand, bool>
    {
        private readonly IEventBus _bus;
        public CreateBreakLogEntryCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(CreateBreakLogEntryCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new BreakLogEntryCreatedEvent(request.BreakLogEntryInstance));
            return Task.FromResult(true);
        }
    }
}
