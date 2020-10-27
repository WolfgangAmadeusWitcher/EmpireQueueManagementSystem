using EmpireQms.SignageService.Api.Domain.Models;
using EmpireQms.SignageService.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmpireQms.SignageService.Api.Persistence.Repositories
{
    public class SignageRepository : Repository<Signage>, ISignageRepository
    {
        private SignageContext _signageContext;

        public SignageRepository(SignageContext context) : base(context, context.Signages)
        {
            _signageContext = context;
        }

        public void UpdateSignage(Signage signage)
        {
            _signageContext.Entry(signage).State = EntityState.Modified;
            _signageContext.SaveChanges();
        }

        public override IEnumerable<Signage> GetAll()
        {
            return _signageContext.Signages.Include(sign => sign.TerminalSignages);
        }
    }
}
