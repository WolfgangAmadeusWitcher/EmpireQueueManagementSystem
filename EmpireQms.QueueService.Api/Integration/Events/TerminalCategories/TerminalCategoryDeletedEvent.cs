using EmpireQms.Domain.Core.Events;
using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Integration.Events.TerminalCategories
{
    public class TerminalCategoryDeletedEvent : Event
    {
        public TerminalCategory TerminalCategory { get; set; }
        public TerminalCategoryDeletedEvent(TerminalCategory terminalCategory)
        {
            TerminalCategory = terminalCategory;
        }
    }
}
