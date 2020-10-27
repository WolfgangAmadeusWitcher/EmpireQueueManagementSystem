using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.TerminalService.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmpireQms.TerminalService.Api.Persistence.Repositories
{
    public class TerminalRepository : Repository<Terminal>, ITerminalRepository
    {
        private TerminalContext _terminalContext;

        public TerminalRepository(TerminalContext context) : base(context, context.Terminals)
        {
            _terminalContext = context;
        }
        public void UpdateTerminal(Terminal terminal)
        {
            _terminalContext.Entry(terminal).State = EntityState.Modified;
            _terminalContext.SaveChanges();
        }
    }
}
