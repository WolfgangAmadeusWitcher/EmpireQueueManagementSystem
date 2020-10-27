using EmpireQms.AdminModule.Api.Domain.Commands.Terminals;
using EmpireQms.AdminModule.Api.Domain.Events.Terminals;
using EmpireQms.Domain.Core.Bus;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Domain.CommandHandlers.Terminals
{
    public class UpdateTerminalSettingsCommandHandler : IRequestHandler<UpdateTerminalSettingsCommand, bool>
    {
        private readonly IEventBus _bus;

        public UpdateTerminalSettingsCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(UpdateTerminalSettingsCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TerminalSettingsUpdatedEvent(request.TerminalSettings));
            return Task.FromResult(true);
        }
    }
}
