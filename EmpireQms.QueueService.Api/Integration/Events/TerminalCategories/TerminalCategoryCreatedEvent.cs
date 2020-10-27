using EmpireQms.Domain.Core.Events;
using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Integration.Events.TerminalCategories
{
    public class TerminalCategoryCreatedEvent : Event
    {
        public TerminalCategory TerminalCategory { get; set; }
        public TerminalCategoryCreatedEvent(TerminalCategory terminalCategory)
        {
            TerminalCategory = terminalCategory;
        }
    }
}
