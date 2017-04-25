namespace Infraestructure.Repository.Mongo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Infraestructure.Repository.Interfaces;
    using MongoDB.Driver;

    public abstract class MongoRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
        where TKey : IComparable<TKey>, IComparable
    {
        private readonly IMongoContext context;

        protected MongoRepository(IMongoContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            this.context = context;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task DeleteManyAsync(IEnumerable<TKey> ids)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IQueryable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return
                await
                this.context.GetCollection<TEntity>()
                    .Find(
                        Builders<TEntity>.Filter.And(                         
                            Builders<TEntity>.Filter.Eq("_id", id)))
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false);
        }

        public virtual async Task<IQueryable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            this.context?.Dispose();
        }
    }
}
