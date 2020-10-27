using EmpireQms.AdminModule.Api.Domain.Commands.TerminalCategories;
using EmpireQms.AdminModule.Api.Domain.Events.TerminalRelatedObjects;
using MediatR;
using EmpireQms.Domain.Core.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Domain.CommandHandlers.TerminalRelatedObjects
{
    public class CreateTerminalCategoryCommandHandler : IRequestHandler<CreateTerminalCategoryCommand, bool>
    {
        private readonly IEventBus _bus;

        public CreateTerminalCategoryCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(CreateTerminalCategoryCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TerminalCategoryCreatedEvent(request.TerminalCategory));
            return Task.FromResult(true);
        }
    }
}
