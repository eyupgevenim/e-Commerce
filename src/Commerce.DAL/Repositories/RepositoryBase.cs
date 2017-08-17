using Commerce.Contracts.Repositories;
using Commerce.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Linq.Expressions;

namespace Commerce.DAL.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        internal DataContext context;
        internal DbSet<TEntity> dbSet;

        public RepositoryBase(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual void Commit()
        {
            context.SaveChanges();
        }

        public virtual async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);

            dbSet.Remove(entity);
        }

        //public virtual void Delete(object id)
        //{
        //    TEntity entity = null;//dbSet.Find(id);
        //    Delete(entity);
        //}
        public abstract void Delete(object id);

        public virtual void Dispose()
        {
            context.Dispose();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public virtual IQueryable<TEntity> GetAll(Func<TEntity, bool> where)
        {
            //need to override in order to implement specific filtering.
            return dbSet.Where(where).AsQueryable();
        }

        //public virtual TEntity GetById(object id)
        //{
        //    return null;// dbSet.Find(id);
        //}
        public abstract TEntity GetById(object id);

        public virtual TEntity GetFullObject(object id)
        {
            return null; //need to override in order to implement specific filtering.

        }

        public virtual IQueryable<TEntity> GetPaged<TKey>(int top = 20, int skip = 0, Func<TEntity,TKey> orderBy = null, Func<TEntity,bool> where = null)
        {
            //need to override in order to implement specific filtering and ordering
            return dbSet.Skip(skip).Take(top).OrderBy(orderBy).Where(where).AsQueryable();
        }

        public virtual IQueryable<TEntity> GetPaged(int top = 20, int skip = 0)
        {
            //need to override in order to implement specific filtering and ordering
            return dbSet.Skip(skip).Take(top);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void RunCommand(string query)
        {
            context.Database.ExecuteSqlCommand(query);
        }

        public async Task RunCommandAsync(string query)
        {
            await context.Database.ExecuteSqlCommandAsync(query);
        }

        public void RunCommandWithParameter(string query, params object[] parameters)
        {
            context.Database.ExecuteSqlCommand(query, parameters);
        }
        
        public async Task RunCommandWithParameterAsync(string query, CancellationToken cancellationToken = default(CancellationToken), params object[] parameters)
        {
            await context.Database.ExecuteSqlCommandAsync(query, cancellationToken, parameters);
        }
    }
}
