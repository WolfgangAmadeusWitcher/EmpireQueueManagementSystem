using EmpireQms.Domain.Core.Bus;
using EmpireQms.QueueService.Api.Domain;
using EmpireQms.QueueService.Api.Domain.Models;
using EmpireQms.QueueService.Api.Integration.Events.TerminalCategories;
using System.Threading.Tasks;

namespace EmpireQms.QueueService.Api.Integration.EventHandlers.TerminalCategories
{
    public class TerminalCategoryCreatedEventHandler : IEventHandler<TerminalCategoryCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TerminalCategoryCreatedEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(TerminalCategoryCreatedEvent @event)
        {
            var createdTerminalCategory = new TerminalCategory
            {
                TerminalId = @event.TerminalCategory.TerminalId,
                TicketCategoryId = @event.TerminalCategory.TicketCategoryId,
            };

            _unitOfWork.TerminalCategories.Create(createdTerminalCategory);
            return Task.CompletedTask;
        }
    }
}
