using EmpireQms.AdminModule.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> Table;
        //protected Dictionary<int, TEntity> _cache;

        public Repository(DbContext dbContext, DbSet<TEntity> table)
        {
            Table = table;
            Context = dbContext;
        }
        public void Create(TEntity entity)
        {
            Table.Add(entity);
            Context.SaveChanges();
            //_cache.Add((int)GetProperty(entity), entity);
        }
        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
            //_cache.Remove((int)GetProperty(entity));
            Context.SaveChanges();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual List<TEntity> GetAll()
        {
           return Context.Set<TEntity>().ToList();
        }

        protected virtual void FillCache(DbSet<TEntity> table, Func<TEntity, int> keySelection)
        {
         //   _cache = table.ToDictionary(keySelection);
        }

        private object GetProperty(TEntity entity)
        {
            Type entityType = entity.GetType();
            PropertyInfo entityProperty = entityType.GetProperty("Id");
            object idField = entityProperty.GetValue(entity);
            return idField;
        }
    }
}
