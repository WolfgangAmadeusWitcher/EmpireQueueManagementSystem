using EmpireQms.AdminModule.Api.Domain.Commands;
using EmpireQms.AdminModule.Api.Domain.Events;
using MediatR;
using EmpireQms.Domain.Core.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Domain.CommandHandlers
{
    public class CreateTicketCategoryCommandHandler : IRequestHandler<CreateTicketCategoryCommand, bool>
    {
        private readonly IEventBus _bus;

        public CreateTicketCategoryCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(CreateTicketCategoryCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TicketCategoryCreatedEvent(request.CommandedTicketCategory));
            return Task.FromResult(true);
        }
    }
}
