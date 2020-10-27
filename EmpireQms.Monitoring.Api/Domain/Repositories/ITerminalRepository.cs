using EmpireQms.Monitoring.Api.Domain.Models;

namespace EmpireQms.Monitoring.Api.Domain.Repositories
{
    public interface ITerminalRepository : IRepository<Terminal>
    {
        void UpdateTerminal(Terminal terminal);
    }
}
