using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.TerminalService.Api.Integration.Events.TerminalCategories
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
