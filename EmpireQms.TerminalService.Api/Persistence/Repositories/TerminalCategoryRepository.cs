using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.TerminalService.Api.Domain.Repositories;

namespace EmpireQms.TerminalService.Api.Persistence.Repositories
{
    public class TerminalCategoryRepository : Repository<TerminalCategory>, ITerminalCategoryRepository
    {
        public TerminalCategoryRepository(TerminalContext context) : base(context, context.TerminalCategories)
        {
            
        }
    }
}
