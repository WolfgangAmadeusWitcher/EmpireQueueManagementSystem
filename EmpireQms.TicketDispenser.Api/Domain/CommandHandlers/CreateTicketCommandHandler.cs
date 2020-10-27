using EmpireQms.Domain.Core.Bus;
using EmpireQms.TicketDispenser.Api.Domain.Commands;
using EmpireQms.TicketDispenser.Api.Integration.Events.Tickets;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.TicketDispenser.Api.Domain.CommandHandlers
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, bool>
    {
        private readonly IEventBus _bus;

        public CreateTicketCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TicketCreatedEvent(request.Ticket));
            return Task.FromResult(true);
        }
    }
}
