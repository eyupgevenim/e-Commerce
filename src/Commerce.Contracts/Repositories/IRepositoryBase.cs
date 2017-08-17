using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Commerce.Contracts.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Commit();
        Task CommitAsync();
        void Delete(object id);
        void Delete(TEntity entity);
        void Dispose();
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Func<TEntity, bool> where = null);
        TEntity GetById(object id);
        TEntity GetFullObject(object id);
        IQueryable<TEntity> GetPaged<TKey>(int top = 20, int skip = 0, Func<TEntity,TKey> orderBy = null, Func<TEntity,bool> where = null);
        IQueryable<TEntity> GetPaged(int top = 20, int skip = 0);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void RunCommand(string query);
        Task RunCommandAsync(string query);
        void RunCommandWithParameter(string query, params object[] parameters);
        Task RunCommandWithParameterAsync(string query, CancellationToken cancellationToken = default(CancellationToken), params object[] parameters);
    }
}