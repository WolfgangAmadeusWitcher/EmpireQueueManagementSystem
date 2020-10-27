using EmpireQms.Domain.Core.Bus;
using EmpireQms.QueueService.Api.Domain;
using EmpireQms.QueueService.Api.Integration.Events.TerminalCategories;
using System.Threading.Tasks;

namespace EmpireQms.QueueService.Api.Integration.EventHandlers.TerminalCategories
{
    public class TerminalCategoryDeletedEventHandler : IEventHandler<TerminalCategoryDeletedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TerminalCategoryDeletedEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(TerminalCategoryDeletedEvent @event)
        {
            _unitOfWork.TerminalCategories.Delete(@event.TerminalCategory);
            return Task.CompletedTask;
        }
    }
}
