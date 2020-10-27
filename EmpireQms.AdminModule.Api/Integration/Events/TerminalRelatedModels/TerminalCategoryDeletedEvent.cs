using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.AdminModule.Api.Domain.Events.TerminalRelatedObjects
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
