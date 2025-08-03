using Microsoft.EntityFrameworkCore;

namespace CMSRepository.Abstractions
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;



        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }



        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }


        public virtual void AddRange(params TEntity[] entities)
        {
            dbSet.AddRange(entities);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }


        public virtual TEntity? Find(params object?[] keyValues)
        {
            return dbSet.Find(keyValues);
        }


        public virtual void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void RemoveRange(params TEntity[] entities)
        {
            dbSet.RemoveRange(entities);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }


        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public virtual void UpdateRange(params TEntity[] entities)
        {
            dbSet.UpdateRange(entities);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            dbSet.UpdateRange(entities);
        }



        public virtual async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual async Task AddAsync(TEntity entity, CancellationToken cs = default)
        {
            await dbSet.AddAsync(entity, cs);
        }


        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cs = default)
        {
            await dbSet.AddRangeAsync(entities, cs);
        }


        public virtual async Task<TEntity?> FindAsync(params object[] keyValues)
        {
            return await dbSet.FindAsync(keyValues);
        }

        public virtual async Task<TEntity?> FindAsync(object[] keyValues, CancellationToken cs = default)
        {
            return await dbSet.FindAsync(keyValues, cs);
        }


        public virtual async Task<int> SaveChangesAsync(CancellationToken cs = default)
        {
            return await dbContext.SaveChangesAsync(cs);
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

    }
}