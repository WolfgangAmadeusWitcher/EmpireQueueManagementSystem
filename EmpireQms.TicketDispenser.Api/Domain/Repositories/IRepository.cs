using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmpireQms.TicketDispenser.Api.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Update(TEntity entity);
        void Create(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
