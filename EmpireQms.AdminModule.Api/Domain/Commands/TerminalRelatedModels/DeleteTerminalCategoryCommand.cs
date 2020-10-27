using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Commands;

namespace EmpireQms.AdminModule.Api.Domain.Commands.TerminalCategories
{
    public class DeleteTerminalCategoryCommand : Command
    {
        public TerminalCategory TerminalCategory { get; set; }
        public DeleteTerminalCategoryCommand(TerminalCategory terminalCategory)
        {
            TerminalCategory = terminalCategory;
        }
    }
}
