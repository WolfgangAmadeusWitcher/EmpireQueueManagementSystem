using EmpireQms.SignageService.Api.Domain.Models;

namespace EmpireQms.SignageService.Api.Domain.Repositories
{
    public interface ISignageRepository : IRepository<Signage> 
    {
        void UpdateSignage(Signage signage);
    }
}
