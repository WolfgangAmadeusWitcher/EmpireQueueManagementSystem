using EmpireQms.Domain.Core.Bus;
using EmpireQms.QueueService.Api.Domain.Commands.Tickets;
using EmpireQms.QueueService.Api.Integration.Events.Tickets;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.QueueService.Api.Domain.CommandHandlers.Tickets
{
    public class CompleteServiceForTerminalCommandHandler : IRequestHandler<CompleteServiceForTerminalCommand, bool>
    {
        private readonly IEventBus _bus;
        public CompleteServiceForTerminalCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(CompleteServiceForTerminalCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new ServiceCompletedForTerminalEvent(request.TerminalId));
            return Task.FromResult(true);
        }
    }
}
