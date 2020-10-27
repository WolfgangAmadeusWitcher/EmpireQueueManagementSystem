using EmpireQms.TerminalService.Api.Domain.Models;

namespace EmpireQms.TerminalService.Api.Domain.Repositories
{
    public interface ITerminalRepository : IRepository<Terminal>
    {
        void UpdateTerminal(Terminal terminal);
    }
}
