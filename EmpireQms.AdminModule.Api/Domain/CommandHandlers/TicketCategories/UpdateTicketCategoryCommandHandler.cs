using EmpireQms.AdminModule.Api.Domain.Commands;
using EmpireQms.AdminModule.Api.Domain.Events;
using MediatR;
using EmpireQms.Domain.Core.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Domain.CommandHandlers
{
    public class UpdateTicketCategoryCommandHandler : IRequestHandler<UpdateTicketCategoryCommand, bool>
    {
        private readonly IEventBus _bus;

        public UpdateTicketCategoryCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(UpdateTicketCategoryCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TicketCategoryUpdatedEvent(request.CommandedTicketCategory));
            return Task.FromResult(true);
        }
    }
}
