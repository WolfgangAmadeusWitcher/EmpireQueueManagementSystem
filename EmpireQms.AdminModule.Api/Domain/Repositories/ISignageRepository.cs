using EmpireQms.AdminModule.Api.Domain.Models;

namespace EmpireQms.AdminModule.Api.Domain.Repositories
{
    public interface ISignageRepository : IRepository<Signage>
    {
        void UpdateSignage(Signage signage);
    }
}
