using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.AdminModule.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmpireQms.AdminModule.Api.Persistence.Repositories
{
    public class TerminalRepository : Repository<Terminal>, ITerminalRepository
    {
        private readonly SettingsContext _settingsContext;
        public TerminalRepository(SettingsContext context) : base(context, context.Terminals)
        {
            _settingsContext = context;
        }

        public void UpdateTerminal(Terminal terminal)
        {
            _settingsContext.Entry(terminal).State = EntityState.Modified;
            _settingsContext.SaveChanges();
        }

        public override List<Terminal> GetAll()
        {
            return _settingsContext.Terminals.Include(t => t.TerminalCategories).Include(t => t.TerminalSignages).ToList();
        }

        public void CreateTerminalCategory(TerminalCategory terminalCategory)
        {
            _settingsContext.TerminalCategories.Add(terminalCategory);
            _settingsContext.SaveChanges();
        }

        public void DeleteTerminalCategory(TerminalCategory terminalCategory)
        {
            _settingsContext.TerminalCategories.Remove(terminalCategory);
            _settingsContext.SaveChanges();
        }

        public void CreateTerminalSignage(TerminalSignage terminalSignage)
        {
            _settingsContext.TerminalSignages.Add(terminalSignage);
            _settingsContext.SaveChanges();
        }

        public void DeleteTerminalSignage(TerminalSignage terminalSignage)
        {
            _settingsContext.TerminalSignages.Remove(terminalSignage);
            _settingsContext.SaveChanges();
        }
    }
}
