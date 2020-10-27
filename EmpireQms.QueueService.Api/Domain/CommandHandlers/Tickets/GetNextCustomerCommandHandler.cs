using EmpireQms.Domain.Core.Bus;
using EmpireQms.QueueService.Api.Domain.Commands;
using EmpireQms.QueueService.Api.Integration.Events.Tickets;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.QueueService.Api.Domain.CommandHandlers.Tickets
{
    public class GetNextCustomerCommandHandler : IRequestHandler<GetNextCustomerCommand, bool>
    {
        private readonly IEventBus _bus;
        public GetNextCustomerCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }
        public Task<bool> Handle(GetNextCustomerCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new NextPersonCalledEvent(request.Ticket.Number, request.TerminalId));
            return Task.FromResult(true);
        }
    }
}
