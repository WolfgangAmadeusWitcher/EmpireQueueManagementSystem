using EmpireQms.TerminalService.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmpireQms.TerminalService.Api.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> Table;
        public Repository(DbContext dbContext, DbSet<TEntity> table)
        {
            Table = table;
            Context = dbContext;
        }
        public void Create(TEntity entity)
        {
            Table.Add(entity);
            Context.SaveChanges();
        }
        public void CreateRange(List<TEntity> entities)
        {
            Table.AddRange(entities);
            Context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
            Context.SaveChanges();
        }
        public void DeleteTable()
        {
            Table.RemoveRange(Table);
            Context.SaveChanges();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.SingleOrDefaultAsync(predicate);
        }

        public TEntity Get(int id)
        {
            return Table.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Table.ToList();
        }
    }
}

