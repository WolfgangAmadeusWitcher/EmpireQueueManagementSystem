using EmpireQms.AdminModule.Api.Domain.Commands.Signages;
using EmpireQms.AdminModule.Api.Integration.Events.Signages;
using EmpireQms.Domain.Core.Bus;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Domain.CommandHandlers.Signages
{
    public class SyncSignagesCommandHandler : IRequestHandler<SyncSignagesCommand, bool>
    {
        private readonly IEventBus _bus;

        public SyncSignagesCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(SyncSignagesCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new SignagesSyncedEvent(request.SignageTable));
            return Task.FromResult(true);
        }
    }
}
