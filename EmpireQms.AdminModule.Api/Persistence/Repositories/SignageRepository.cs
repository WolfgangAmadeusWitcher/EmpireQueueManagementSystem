using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.AdminModule.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmpireQms.AdminModule.Api.Persistence.Repositories
{
    public class SignageRepository : Repository<Signage>, ISignageRepository
    {
        private SettingsContext _settingsContext;

        public SignageRepository(SettingsContext context) : base(context, context.Signages)
        {
            _settingsContext = context;
        }

        public void UpdateSignage(Signage signage)
        {
            _settingsContext.Entry(signage).State = EntityState.Modified;
            _settingsContext.SaveChanges();
        }
    }
}
