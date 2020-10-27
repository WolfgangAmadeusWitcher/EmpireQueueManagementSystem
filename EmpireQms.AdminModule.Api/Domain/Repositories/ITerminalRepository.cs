using EmpireQms.AdminModule.Api.Domain.Models;

namespace EmpireQms.AdminModule.Api.Domain.Repositories
{
    public interface ITerminalRepository : IRepository<Terminal>
    {
        void UpdateTerminal(Terminal terminal);
        void CreateTerminalCategory(TerminalCategory terminalCategory);
        void DeleteTerminalCategory(TerminalCategory terminalCategory);
        void CreateTerminalSignage(TerminalSignage terminalSignage);
        void DeleteTeminalSignage(TerminalSignage terminalSignage);
    }
}
