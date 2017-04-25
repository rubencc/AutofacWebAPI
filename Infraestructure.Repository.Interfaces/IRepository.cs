namespace Infraestructure.Repository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<TEntity, in TKey> : IDisposable
        where TEntity : class
        where TKey : IComparable<TKey>, IComparable
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(TKey id);
        Task DeleteManyAsync(IEnumerable<TKey> ids);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TKey id);
        Task<IQueryable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> filter);
    }
}
