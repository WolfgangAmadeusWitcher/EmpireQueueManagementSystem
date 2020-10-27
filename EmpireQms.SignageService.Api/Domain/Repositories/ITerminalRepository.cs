using EmpireQms.SignageService.Api.Domain.Models;

namespace EmpireQms.SignageService.Api.Domain.Repositories
{
    public interface ITerminalRepository : IRepository<Terminal>
    {
        void UpdateTerminal(Terminal terminal);
    }
}
