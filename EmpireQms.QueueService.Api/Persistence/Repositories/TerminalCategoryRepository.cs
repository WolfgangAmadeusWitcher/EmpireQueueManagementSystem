using EmpireQms.QueueService.Api.Domain.Models;
using EmpireQms.QueueService.Api.Domain.Repositories;

namespace EmpireQms.QueueService.Api.Persistence.Repositories
{
    public class TerminalCategoryRepository : Repository<TerminalCategory>, ITerminalCategoryRepository
    {
        public TerminalCategoryRepository(QueueContext context) : base(context, context.TerminalCategories)
        {

        }
    }
}
