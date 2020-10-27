using EmpireQms.AdminModule.Api.Domain.Commands.Signages;
using EmpireQms.AdminModule.Api.Integration.Events.Signages;
using EmpireQms.Domain.Core.Bus;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Domain.CommandHandlers.Signages
{
    public class DeleteSignageCommandHandler : IRequestHandler<DeleteSignageCommand, bool>
    {
        private readonly IEventBus _bus;

        public DeleteSignageCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(DeleteSignageCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new SignageDeletedEvent(request.Signage));
            return Task.FromResult(true);
        }
    }
}
