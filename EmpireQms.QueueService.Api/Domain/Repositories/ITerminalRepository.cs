using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Domain.Repositories
{
    public interface ITerminalRepository : IRepository<Terminal>
    {
        void UpdateTerminal(Terminal terminal);
    }
}
