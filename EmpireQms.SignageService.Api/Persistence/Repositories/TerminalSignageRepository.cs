using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Domain.Repositories;

namespace EmpireQms.SignageService.Api.Persistence.Repositories
{
    public class TerminalSignageRepository : Repository<TerminalSignage>, ITerminalSignageRepository
    {
        public TerminalSignageRepository(SignageContext context) : base(context, context.TerminalSignages)
        {

        }
    }
}
