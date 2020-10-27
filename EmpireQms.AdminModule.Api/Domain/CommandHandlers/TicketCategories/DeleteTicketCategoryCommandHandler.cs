using EmpireQms.AdminModule.Api.Domain.Commands;
using EmpireQms.AdminModule.Api.Domain.Events;
using MediatR;
using EmpireQms.Domain.Core.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Domain.CommandHandlers
{
    public class DeleteTicketCategoryCommandHandler : IRequestHandler<DeleteTicketCategoryCommand, bool>
    {
        private readonly IEventBus _bus;

        public DeleteTicketCategoryCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(DeleteTicketCategoryCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TicketCategoryDeletedEvent(request.CommandedTicketCategory));
            return Task.FromResult(true);
        }
    }
}
