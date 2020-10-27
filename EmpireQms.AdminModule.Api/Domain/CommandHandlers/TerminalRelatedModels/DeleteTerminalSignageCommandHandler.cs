using EmpireQms.AdminModule.Api.Domain.Commands.TerminalRelatedObjects;
using EmpireQms.AdminModule.Api.Domain.Events.TerminalRelatedObjects;
using MediatR;
using EmpireQms.Domain.Core.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Domain.CommandHandlers.TerminalRelatedObjects
{
    public class DeleteTerminalSignageCommandHandler : IRequestHandler<DeleteTerminalSignageCommand, bool>
    {
        private readonly IEventBus _bus;

        public DeleteTerminalSignageCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(DeleteTerminalSignageCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TerminalSignageDeletedEvent(request.TerminalSignage));
            return Task.FromResult(true);
        }
    }
}
