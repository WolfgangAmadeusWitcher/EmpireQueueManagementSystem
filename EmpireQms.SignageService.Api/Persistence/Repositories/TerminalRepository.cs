using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmpireQms.SignageService.Api.Persistence.Repositories
{
    public class TerminalRepository : Repository<Terminal>, ITerminalRepository
    {
        private SignageContext _signageContext;

        public TerminalRepository(SignageContext context) : base(context, context.Terminals)
        {
            _signageContext = context;
        }
        public void UpdateTerminal(Terminal terminal)
        {
            _signageContext.Entry(terminal).State = EntityState.Modified;
            _signageContext.SaveChanges();
        }
        public override IEnumerable<Terminal> GetAll()
        {
            return _signageContext.Terminals.Include(term => term.TerminalSignages);
        }
    }
}
