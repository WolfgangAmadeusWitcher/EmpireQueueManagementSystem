using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Commands;

namespace EmpireQms.AdminModule.Api.Domain.Commands.TerminalCategories
{
    public class CreateTerminalCategoryCommand : Command
    {
        public TerminalCategory TerminalCategory { get; set; }
        public CreateTerminalCategoryCommand(TerminalCategory terminalCategory)
        {
            TerminalCategory = terminalCategory;
        }
    }
}
