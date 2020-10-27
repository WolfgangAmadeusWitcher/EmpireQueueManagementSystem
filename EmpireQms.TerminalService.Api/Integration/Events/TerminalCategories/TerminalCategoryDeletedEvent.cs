using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.TerminalService.Api.Integration.Events.TerminalCategories
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
